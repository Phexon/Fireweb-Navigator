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
// Generated by IDLImporter from file nsIRDFInferDataSource.idl
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
    /// An nsIRDFInferDataSource is implemented by a infer engine. This
    /// engine mimics assertions in addition to those in the baseDataSource
    /// according to a particular vocabulary.
    /// Infer engines have contract IDs in the form of
    /// "@mozilla.org/rdf/infer-datasource;1?engine="
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("2b04860f-4017-40f6-8a57-784a1e35077a")]
	public interface nsIRDFInferDataSource : nsIRDFDataSource
	{
		
		/// <summary>
        ///The "URI" of the data source. This used by the RDF service's
        /// |GetDataSource()| method to cache datasources.
        /// </summary>
		[return: MarshalAs(UnmanagedType.LPStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new string GetURIAttribute();
		
		/// <summary>
        ///Find an RDF resource that points to a given node over the
        /// specified arc & truth value
        ///
        /// @return NS_RDF_NO_VALUE if there is no source that leads
        /// to the target with the specified property.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIRDFResource GetSource([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aTarget, [MarshalAs(UnmanagedType.U1)] bool aTruthValue);
		
		/// <summary>
        /// Find all RDF resources that point to a given node over the
        /// specified arc & truth value
        ///
        /// @return NS_OK unless a catastrophic error occurs. If the
        /// method returns NS_OK, you may assume that nsISimpleEnumerator points
        /// to a valid (but possibly empty) cursor.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISimpleEnumerator GetSources([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aTarget, [MarshalAs(UnmanagedType.U1)] bool aTruthValue);
		
		/// <summary>
        /// Find a child of that is related to the source by the given arc
        /// arc and truth value
        ///
        /// @return NS_RDF_NO_VALUE if there is no target accessible from the
        /// source via the specified property.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIRDFNode GetTarget([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.U1)] bool aTruthValue);
		
		/// <summary>
        /// Find all children of that are related to the source by the given arc
        /// arc and truth value.
        ///
        /// @return NS_OK unless a catastrophic error occurs. If the
        /// method returns NS_OK, you may assume that nsISimpleEnumerator points
        /// to a valid (but possibly empty) cursor.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISimpleEnumerator GetTargets([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.U1)] bool aTruthValue);
		
		/// <summary>
        /// Add an assertion to the graph.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Assert([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aTarget, [MarshalAs(UnmanagedType.U1)] bool aTruthValue);
		
		/// <summary>
        /// Remove an assertion from the graph.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Unassert([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aTarget);
		
		/// <summary>
        /// Change an assertion from
        ///
        /// [aSource]--[aProperty]-->[aOldTarget]
        ///
        /// to
        ///
        /// [aSource]--[aProperty]-->[aNewTarget]
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Change([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aOldTarget, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aNewTarget);
		
		/// <summary>
        /// 'Move' an assertion from
        ///
        /// [aOldSource]--[aProperty]-->[aTarget]
        ///
        /// to
        ///
        /// [aNewSource]--[aProperty]-->[aTarget]
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Move([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aOldSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aNewSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aTarget);
		
		/// <summary>
        /// Query whether an assertion exists in this graph.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool HasAssertion([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aTarget, [MarshalAs(UnmanagedType.U1)] bool aTruthValue);
		
		/// <summary>
        /// Add an observer to this data source. If the datasource
        /// supports observers, the datasource source should hold a strong
        /// reference to the observer.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void AddObserver([MarshalAs(UnmanagedType.Interface)] nsIRDFObserver aObserver);
		
		/// <summary>
        /// Remove an observer from this data source.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void RemoveObserver([MarshalAs(UnmanagedType.Interface)] nsIRDFObserver aObserver);
		
		/// <summary>
        /// Get a cursor to iterate over all the arcs that point into a node.
        ///
        /// @return NS_OK unless a catastrophic error occurs. If the method
        /// returns NS_OK, you may assume that labels points to a valid (but
        /// possible empty) nsISimpleEnumerator object.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISimpleEnumerator ArcLabelsIn([MarshalAs(UnmanagedType.Interface)] nsIRDFNode aNode);
		
		/// <summary>
        /// Get a cursor to iterate over all the arcs that originate in
        /// a resource.
        ///
        /// @return NS_OK unless a catastrophic error occurs. If the method
        /// returns NS_OK, you may assume that labels points to a valid (but
        /// possible empty) nsISimpleEnumerator object.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISimpleEnumerator ArcLabelsOut([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource);
		
		/// <summary>
        /// Retrieve all of the resources that the data source currently
        /// refers to.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISimpleEnumerator GetAllResources();
		
		/// <summary>
        /// Returns whether a given command is enabled for a set of sources.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool IsCommandEnabled([MarshalAs(UnmanagedType.Interface)] nsISupportsArray aSources, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aCommand, [MarshalAs(UnmanagedType.Interface)] nsISupportsArray aArguments);
		
		/// <summary>
        /// Perform the specified command on set of sources.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void DoCommand([MarshalAs(UnmanagedType.Interface)] nsISupportsArray aSources, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aCommand, [MarshalAs(UnmanagedType.Interface)] nsISupportsArray aArguments);
		
		/// <summary>
        /// Returns the set of all commands defined for a given source.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISimpleEnumerator GetAllCmds([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource);
		
		/// <summary>
        /// Returns true if the specified node is pointed to by the specified arc.
        /// Equivalent to enumerating ArcLabelsIn and comparing for the specified arc.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool HasArcIn([MarshalAs(UnmanagedType.Interface)] nsIRDFNode aNode, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aArc);
		
		/// <summary>
        /// Returns true if the specified node has the specified outward arc.
        /// Equivalent to enumerating ArcLabelsOut and comparing for the specified arc.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool HasArcOut([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aArc);
		
		/// <summary>
        /// Notify observers that the datasource is about to send several
        /// notifications at once.
        /// This must be followed by calling endUpdateBatch(), otherwise
        /// viewers will get out of sync.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void BeginUpdateBatch();
		
		/// <summary>
        /// Notify observers that the datasource has completed issuing
        /// a notification group.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void EndUpdateBatch();
		
		/// <summary>
        ///
        /// The wrapped datasource.
        ///
        /// The InferDataSource contains all arcs from the wrapped
        /// datasource plus those infered by the vocabulary implemented
        /// by the InferDataSource.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIRDFDataSource GetBaseDataSourceAttribute();
		
		/// <summary>
        ///
        /// The wrapped datasource.
        ///
        /// The InferDataSource contains all arcs from the wrapped
        /// datasource plus those infered by the vocabulary implemented
        /// by the InferDataSource.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetBaseDataSourceAttribute([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aBaseDataSource);
	}
}
