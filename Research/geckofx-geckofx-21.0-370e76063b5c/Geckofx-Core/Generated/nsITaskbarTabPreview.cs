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
// Generated by IDLImporter from file nsITaskbarTabPreview.idl
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
    /// nsITaskbarTabPreview
    ///
    /// This interface controls tab preview-specific behavior. Creating an
    /// nsITaskbarTabPreview for a window will hide that window's
    /// nsITaskbarWindowPreview in the taskbar - the native API performs this
    /// unconditionally. When there are no more tab previews for a window, the
    /// nsITaskbarWindowPreview will automatically become visible again.
    ///
    /// An application may have as many tab previews per window as memory allows.
    ///
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("11E4C8BD-5C2D-4E1A-A9A1-79DD5B0FE544")]
	public interface nsITaskbarTabPreview : nsITaskbarPreview
	{
		
		/// <summary>
        /// The controller for this preview. A controller is required to provide
        /// the behavior and appearance of the taskbar previews. It is responsible for
        /// determining the size and contents of the preview, which buttons are
        /// displayed and how the application responds to user actions on the preview.
        ///
        /// Neither preview makes full use of the controller. See the documentation
        /// for nsITaskbarWindowPreview and nsITaskbarTabPreview for details on which
        /// controller methods are used.
        ///
        /// The controller is not allowed to be null.
        ///
        /// @see nsITaskbarPreviewController
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsITaskbarPreviewController GetControllerAttribute();
		
		/// <summary>
        /// The controller for this preview. A controller is required to provide
        /// the behavior and appearance of the taskbar previews. It is responsible for
        /// determining the size and contents of the preview, which buttons are
        /// displayed and how the application responds to user actions on the preview.
        ///
        /// Neither preview makes full use of the controller. See the documentation
        /// for nsITaskbarWindowPreview and nsITaskbarTabPreview for details on which
        /// controller methods are used.
        ///
        /// The controller is not allowed to be null.
        ///
        /// @see nsITaskbarPreviewController
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetControllerAttribute([MarshalAs(UnmanagedType.Interface)] nsITaskbarPreviewController aController);
		
		/// <summary>
        /// The tooltip displayed above the preview when the user hovers over it
        ///
        /// Default: an empty string
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetTooltipAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aTooltip);
		
		/// <summary>
        /// The tooltip displayed above the preview when the user hovers over it
        ///
        /// Default: an empty string
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetTooltipAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aTooltip);
		
		/// <summary>
        /// Whether or not the preview is visible.
        ///
        /// Changing this option is expensive for tab previews since toggling this
        /// option will destroy/create the proxy window and its registration with the
        /// taskbar. If any step of that fails, an exception will be thrown.
        ///
        /// For window previews, this operation is very cheap.
        ///
        /// Default: false
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool GetVisibleAttribute();
		
		/// <summary>
        /// Whether or not the preview is visible.
        ///
        /// Changing this option is expensive for tab previews since toggling this
        /// option will destroy/create the proxy window and its registration with the
        /// taskbar. If any step of that fails, an exception will be thrown.
        ///
        /// For window previews, this operation is very cheap.
        ///
        /// Default: false
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetVisibleAttribute([MarshalAs(UnmanagedType.U1)] bool aVisible);
		
		/// <summary>
        /// Gets/sets whether or not the preview is marked active (selected) in the
        /// taskbar.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool GetActiveAttribute();
		
		/// <summary>
        /// Gets/sets whether or not the preview is marked active (selected) in the
        /// taskbar.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetActiveAttribute([MarshalAs(UnmanagedType.U1)] bool aActive);
		
		/// <summary>
        /// Invalidates the taskbar's cached image of this preview, forcing a redraw
        /// if necessary
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Invalidate();
		
		/// <summary>
        /// The title displayed above the thumbnail
        ///
        /// Default: an empty string
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetTitleAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aTitle);
		
		/// <summary>
        /// The title displayed above the thumbnail
        ///
        /// Default: an empty string
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetTitleAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aTitle);
		
		/// <summary>
        /// The icon displayed next to the title in the preview
        ///
        /// Default: null
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		imgIContainer GetIconAttribute();
		
		/// <summary>
        /// The icon displayed next to the title in the preview
        ///
        /// Default: null
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetIconAttribute(imgIContainer aIcon);
		
		/// <summary>
        /// Rearranges the preview relative to another tab preview from the same window
        /// @param aNext The preview to the right of this one. A value of null
        /// indicates that the preview is the rightmost one.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Move([MarshalAs(UnmanagedType.Interface)] nsITaskbarTabPreview aNext);
		
		/// <summary>
        /// Used internally to grab the handle to the proxy window.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetHWND();
		
		/// <summary>
        /// Used internally to ensure that the taskbar knows about this preview. If a
        /// preview is not registered, then the API call to set its sibling (via move)
        /// will silently fail.
        ///
        /// This method is only invoked when it is safe to make taskbar API calls.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void EnsureRegistration();
	}
}
