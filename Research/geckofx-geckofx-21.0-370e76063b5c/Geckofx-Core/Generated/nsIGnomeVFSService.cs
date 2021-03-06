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
// Generated by IDLImporter from file nsIGnomeVFSService.idl
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
    ///nsIGnomeVFSMimeApp holds information about an application that is looked up
    ///   with nsIGnomeVFSService::GetAppForMimeType. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("66009894-9877-405b-9321-bf30420e34e6")]
	public interface nsIGnomeVFSMimeApp
	{
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetIdAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aId);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetNameAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aName);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetCommandAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aCommand);
		
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetCanOpenMultipleFilesAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetExpectsURIsAttribute();
		
		/// <summary>
        /// see constants above
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIUTF8StringEnumerator GetSupportedURISchemesAttribute();
		
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetRequiresTerminalAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Launch([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase uri);
	}
	
	/// <summary>nsIGnomeVFSMimeAppConsts </summary>
	public class nsIGnomeVFSMimeAppConsts
	{
		
		// <summary>
        //nsIGnomeVFSMimeApp holds information about an application that is looked up
        //   with nsIGnomeVFSService::GetAppForMimeType. </summary>
		public const long EXPECTS_URIS = 0;
		
		// 
		public const long EXPECTS_PATHS = 1;
		
		// 
		public const long EXPECTS_URIS_FOR_NON_FILES = 2;
	}
	
	/// <summary>
    /// The VFS service makes use of a registry for information.
    ///
    /// The MIME registry holds information about MIME types, such as which
    /// extensions map to a given MIME type.  The MIME registry also stores the
    /// id of the application selected to handle each MIME type.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("d1ac73a6-2ceb-4164-8142-215afe7fe8a6")]
	public interface nsIGnomeVFSService
	{
		
		/// <summary>
        ///Obtain the MIME type registered for an extension.  The extension
        ///     should not include a leading dot. </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetMimeTypeFromExtension([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase extension, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase retval);
		
		/// <summary>
        ///Obtain the preferred application for opening a given MIME type </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIGnomeVFSMimeApp GetAppForMimeType([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase mimeType);
		
		/// <summary>
        ///Obtain a description for the given MIME type </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetDescriptionForMimeType([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase mimeType, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase retval);
		
		/// <summary>
        ///Open the given URI in the default application </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ShowURI([MarshalAs(UnmanagedType.Interface)] nsIURI uri);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ShowURIForInput([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase uri);
	}
}
