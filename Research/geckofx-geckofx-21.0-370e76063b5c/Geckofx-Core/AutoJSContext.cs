﻿#region ***** BEGIN LICENSE BLOCK *****
/* Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The Original Code is Skybound Software code.
 *
 * The Initial Developer of the Original Code is Skybound Software.
 * Portions created by the Initial Developer are Copyright (C) 2008-2009
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 */
#endregion END LICENSE BLOCK

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gecko
{
	/// <summary>
	/// Creates a scoped, fake "system principal" security context.  This class is used primarly to work around bugs in gecko
	/// which prevent methods on nsIDOMCSSStyleSheet from working outside of javascript.
	/// </summary>
	public class AutoJSContext : IDisposable
	{			
		IntPtr _cx;
		
		public IntPtr ContextPointer { get { return _cx; } }

		private readonly nsIJSContextStack _contextStack;		
		static private nsIXPConnect _xpConnect;

		/// <summary>
		/// Create a AutoJSContext using the SafeJSContext.
		/// If context is IntPtr.Zero use the SafeJSContext
		/// </summary>
		/// <param name="context"></param>
		public AutoJSContext(IntPtr context)
		{
			if (context == IntPtr.Zero)
			{
				context = GlobalJSContextHolder.SafeJSContext;
			}
			
			_cx = context;			

			// TODO: calling BeginRequest may not be neccessary anymore.
			// begin a new request
			SpiderMonkey.JS_BeginRequest(_cx);

			// TODO: pushing the context onto the context stack may not be neccessary anymore.
			// push the context onto the context stack
			_contextStack = Xpcom.GetService<nsIJSContextStack>("@mozilla.org/js/xpc/ContextStack;1");
			_contextStack.Push(_cx);
		}

		/// <summary>
		/// Create a AutoJSContext using the SafeJSContext.
		/// </summary>		
		public AutoJSContext() : this(IntPtr.Zero)
		{
		}

		private nsIXPConnect XPConnect
		{
			get
			{
				if (_xpConnect == null)
				{
					var xpcomPtr = (IntPtr)Xpcom.GetService(new Guid("CB6593E0-F9B2-11d2-BDD6-000064657374"));
					_xpConnect = (nsIXPConnect)Xpcom.GetObjectForIUnknown(xpcomPtr);
				}
				return _xpConnect;
			}
		}

		/// <summary>
		/// Evaluate javascript in the current context.
		/// </summary>
		/// <param name="jsScript"></param>
		/// <param name="jsval"></param>
		/// <returns></returns>
		public bool EvaluateScript(string jsScript, out string result)
		{
			var ptr = new JsVal();
			IntPtr globalObject = SpiderMonkey.JS_GetGlobalForScopeChain(_cx);
			bool ret = SpiderMonkey.JS_EvaluateScript(_cx, globalObject, jsScript, (uint)jsScript.Length, "script", 1, ref ptr);
			// TODO: maybe getting JS_EvaluateScriptForPrincipals working would increase priviliges of the running script.
			//bool ret = SpiderMonkey.JS_EvaluateScriptForPrincipals(_cx, globalObject, ..., jsScript, (uint)jsScript.Length,"script", 1, ref ptr);
			

			IntPtr jsStringPtr = SpiderMonkey.JS_ValueToString(_cx, ptr);
			result = Marshal.PtrToStringAnsi(SpiderMonkey.JS_EncodeString(_cx, jsStringPtr));
			return ret;
		}

		/// <summary>
		/// Evaluate javascript in the current context.
		/// </summary>
		/// <param name="jsScript"></param>
		/// <param name="thisObject">a nsISupports com object that this is set too.</param>
		/// <param name="result"></param>
		/// <returns></returns>
		public bool EvaluateScript(string jsScript, nsISupports thisObject, out string result)
		{
			try
			{
				Guid guid = typeof(nsISupports).GUID;
				IntPtr globalObject = SpiderMonkey.JS_GetGlobalForScopeChain(_cx);
				var ptr = new JsVal();
				var wrapper = XPConnect.WrapNative(_cx, globalObject, thisObject, ref guid);				
				bool ret = SpiderMonkey.JS_EvaluateScript(_cx, wrapper.GetJSObjectAttribute(), jsScript, (uint)jsScript.Length, "script", 1, ref ptr);				
				IntPtr jsStringPtr = SpiderMonkey.JS_ValueToString(_cx, ptr);
				result = Marshal.PtrToStringAnsi(SpiderMonkey.JS_EncodeString(_cx, jsStringPtr));
				return ret;
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				result = String.Empty;
				return false;
			}
		}

		/// <summary>
		/// Evaluate javascript in the current context with system privileges.
		/// </summary>
		/// <param name="jsScript"></param>
		/// <param name="jsval"></param>
		/// <returns></returns>
		public bool EvaluateTrustedScript(string jsScript, out string result)
		{
			var ptr = new JsVal();
			IntPtr globalObject = SpiderMonkey.JS_GetGlobalForScopeChain(_cx);
			bool ret;
			IntPtr systemGlobalObject = SpiderMonkey.JS_GetGlobalForScopeChain(GlobalJSContextHolder.BackstageJSContext);
			// Compartments have to be entered and left in LIFO order.
			bool inSystemCompartment = false;
			IntPtr oldCompartment = IntPtr.Zero;
			try
			{
				// Allow access to any object on page.
				oldCompartment = SpiderMonkey.JS_EnterCompartment(_cx, systemGlobalObject);
				// At any time, a JSContext has a current (possibly-NULL) compartment.
				inSystemCompartment = true;
				ret = SpiderMonkey.JS_EvaluateScript(_cx, globalObject, jsScript, (uint)jsScript.Length, "script", 1, ref ptr);
				IntPtr jsStringPtr = SpiderMonkey.JS_ValueToString(_cx, ptr);
				result = Marshal.PtrToStringAnsi(SpiderMonkey.JS_EncodeString(_cx, jsStringPtr));
			}
			finally
			{
				if (inSystemCompartment)
					SpiderMonkey.JS_LeaveCompartment(_cx, oldCompartment);
			}
			return ret;
		}

		public nsISupports GetGlobalNsObject()
		{
			IntPtr globalObject = SpiderMonkey.JS_GetGlobalObject(_cx);
			if (globalObject != IntPtr.Zero)
			{
				Guid guid = typeof(nsISupports).GUID;

				IntPtr pUnk = IntPtr.Zero;
				try
				{
					pUnk = XPConnect.WrapJS(_cx, globalObject, ref guid);
					return (nsISupports)Xpcom.GetObjectForIUnknown(pUnk);
				}
				finally
				{
					if (pUnk != IntPtr.Zero)
						Marshal.Release(pUnk);
				}
			}
			return null;
		}

		public void Dispose()
		{
			_contextStack.Pop();

			SpiderMonkey.JS_EndRequest(_cx);
		}
	}
}
