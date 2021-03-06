// --------------------------------------------------------------------------------------------
// Version: MPL 1.1/GPL 2.0/LGPL 2.1
// 
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
// 
// <remarks>
// Generated by IDLImporter from file nsIIndexedDatabaseManager.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using System.Runtime.CompilerServices;
	
	
	/// <summary>
    ///This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this
    /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("38f15cc7-2df0-4a90-8b7f-1606b2243522")]
	public interface nsIIndexedDatabaseUsageCallback
	{
		
		/// <summary>
        ///This Source Code Form is subject to the terms of the Mozilla Public
        /// License, v. 2.0. If a copy of the MPL was not distributed with this
        /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnUsageResult([MarshalAs(UnmanagedType.Interface)] nsIURI aURI, ulong aUsage, ulong aFileUsage, uint aAppId, [MarshalAs(UnmanagedType.U1)] bool aInMozBrowserOnly);
	}
	
	/// <summary>nsIIndexedDatabaseManager </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("e5168115-baff-4559-887e-7c0405cc9e63")]
	public interface nsIIndexedDatabaseManager
	{
		
		/// <summary>
        /// Schedules an asynchronous callback that will return the total amount of
        /// disk space being used by databases for the given origin.
        ///
        /// @param aURI
        /// The URI whose usage is being queried.
        /// @param aCallback
        /// The callback that will be called when the usage is available.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetUsageForURI([MarshalAs(UnmanagedType.Interface)] nsIURI aURI, [MarshalAs(UnmanagedType.Interface)] nsIIndexedDatabaseUsageCallback aCallback, uint aAppId, [MarshalAs(UnmanagedType.U1)] bool aInMozBrowserOnly, int argc);
		
		/// <summary>
        /// Cancels an asynchronous usage check initiated by a previous call to
        /// getUsageForURI().
        ///
        /// @param aURI
        /// The URI whose usage is being queried.
        /// @param aCallback
        /// The callback that will be called when the usage is available.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CancelGetUsageForURI([MarshalAs(UnmanagedType.Interface)] nsIURI aURI, [MarshalAs(UnmanagedType.Interface)] nsIIndexedDatabaseUsageCallback aCallback, uint aAppId, [MarshalAs(UnmanagedType.U1)] bool aInMozBrowserOnly, int argc);
		
		/// <summary>
        /// Removes all databases stored for the given URI. The files may not be
        /// deleted immediately depending on prohibitive concurrent operations.
        ///
        /// @param aURI
        /// The URI whose databases are to be cleared.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ClearDatabasesForURI([MarshalAs(UnmanagedType.Interface)] nsIURI aURI, uint aAppId, [MarshalAs(UnmanagedType.U1)] bool aInMozBrowserOnly, int argc);
		
		/// <summary>
        /// Defines indexedDB and IDBKeyrange with its static functions on
        /// aObject and initializes DOM exception providers if needed.
        ///
        /// @param aObject
        /// The object, indexedDB and IDBKeyrange should be defined on.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void InitWindowless(Gecko.JsVal aObject, System.IntPtr jsContext);
	}
}
