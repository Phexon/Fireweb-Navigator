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
// Generated by IDLImporter from file nsIAccessibleProvider.idl
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
    /// nsIAccessibleProvider interface is used to link element and accessible
    ///   object. For that XBL binding of element should implement the interface.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("f7e531b6-bc29-4d3d-8c91-60fc2b71eb40")]
	public interface nsIAccessibleProvider
	{
		
		/// <summary>
        /// Return one of constants declared above.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetAccessibleTypeAttribute();
	}
	
	/// <summary>nsIAccessibleProviderConsts </summary>
	public class nsIAccessibleProviderConsts
	{
		
		// <summary>
        //Do not create an accessible for this object
        // This is useful if an ancestor binding already implements nsIAccessibleProvider,
        // but no accessible is desired for the inheriting binding
        // </summary>
		public const long NoAccessible = 0;
		
		// <summary>
        //For elements that spawn a new document. For example now it is used by
        //    <xul:iframe>, <xul:browser> and <xul:editor>. </summary>
		public const long OuterDoc = 0x00000001;
		
		// <summary>
        // Constants set is used by XUL controls.
        // </summary>
		public const long XULAlert = 0x00001001;
		
		// 
		public const long XULButton = 0x00001002;
		
		// 
		public const long XULCheckbox = 0x00001003;
		
		// 
		public const long XULColorPicker = 0x00001004;
		
		// 
		public const long XULColorPickerTile = 0x00001005;
		
		// 
		public const long XULCombobox = 0x00001006;
		
		// 
		public const long XULDropmarker = 0x00001007;
		
		// 
		public const long XULGroupbox = 0x00001008;
		
		// 
		public const long XULImage = 0x00001009;
		
		// 
		public const long XULLink = 0x0000100A;
		
		// 
		public const long XULListbox = 0x0000100B;
		
		// 
		public const long XULListCell = 0x00001026;
		
		// 
		public const long XULListHead = 0x00001024;
		
		// 
		public const long XULListHeader = 0x00001025;
		
		// 
		public const long XULListitem = 0x0000100C;
		
		// 
		public const long XULMenubar = 0x0000100D;
		
		// 
		public const long XULMenuitem = 0x0000100E;
		
		// 
		public const long XULMenupopup = 0x0000100F;
		
		// 
		public const long XULMenuSeparator = 0x00001010;
		
		// 
		public const long XULPane = 0x00001011;
		
		// 
		public const long XULProgressMeter = 0x00001012;
		
		// 
		public const long XULScale = 0x00001013;
		
		// 
		public const long XULStatusBar = 0x00001014;
		
		// 
		public const long XULRadioButton = 0x00001015;
		
		// 
		public const long XULRadioGroup = 0x00001016;
		
		// <summary>
        //Used for XUL tab element </summary>
		public const long XULTab = 0x00001017;
		
		// <summary>
        //Used for XUL tabs element, a container for tab elements </summary>
		public const long XULTabs = 0x00001018;
		
		// <summary>
        //Used for XUL tabpanels element </summary>
		public const long XULTabpanels = 0x00001019;
		
		// 
		public const long XULText = 0x0000101A;
		
		// 
		public const long XULTextBox = 0x0000101B;
		
		// 
		public const long XULThumb = 0x0000101C;
		
		// 
		public const long XULTree = 0x0000101D;
		
		// 
		public const long XULTreeColumns = 0x0000101E;
		
		// 
		public const long XULTreeColumnItem = 0x0000101F;
		
		// 
		public const long XULToolbar = 0x00001020;
		
		// 
		public const long XULToolbarSeparator = 0x00001021;
		
		// 
		public const long XULTooltip = 0x00001022;
		
		// 
		public const long XULToolbarButton = 0x00001023;
	}
}
