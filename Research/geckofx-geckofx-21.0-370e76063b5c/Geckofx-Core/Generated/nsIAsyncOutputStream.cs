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
// Generated by IDLImporter from file nsIAsyncOutputStream.idl
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
    /// If an output stream is non-blocking, it may return NS_BASE_STREAM_WOULD_BLOCK
    /// when written to.  The caller must then wait for the stream to become
    /// writable.  If the stream implements nsIAsyncOutputStream, then the caller can
    /// use this interface to request an asynchronous notification when the stream
    /// becomes writable or closed (via the AsyncWait method).
    ///
    /// While this interface is almost exclusively used with non-blocking streams, it
    /// is not necessary that nsIOutputStream::isNonBlocking return true.  Nor is it
    /// necessary that a non-blocking nsIOutputStream implementation also implement
    /// nsIAsyncOutputStream.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("beb632d3-d77a-4e90-9134-f9ece69e8200")]
	public interface nsIAsyncOutputStream : nsIOutputStream
	{
		
		/// <summary>
        /// Close the stream. Forces the output stream to flush any buffered data.
        ///
        /// @throws NS_BASE_STREAM_WOULD_BLOCK if unable to flush without blocking
        /// the calling thread (non-blocking mode only)
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Close();
		
		/// <summary>
        /// Flush the stream.
        ///
        /// @throws NS_BASE_STREAM_WOULD_BLOCK if unable to flush without blocking
        /// the calling thread (non-blocking mode only)
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Flush();
		
		/// <summary>
        /// Write data into the stream.
        ///
        /// @param aBuf the buffer containing the data to be written
        /// @param aCount the maximum number of bytes to be written
        ///
        /// @return number of bytes written (may be less than aCount)
        ///
        /// @throws NS_BASE_STREAM_WOULD_BLOCK if writing to the output stream would
        /// block the calling thread (non-blocking mode only)
        /// @throws <other-error> on failure
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new uint Write([MarshalAs(UnmanagedType.LPStr)] string aBuf, uint aCount);
		
		/// <summary>
        /// Writes data into the stream from an input stream.
        ///
        /// @param aFromStream the stream containing the data to be written
        /// @param aCount the maximum number of bytes to be written
        ///
        /// @return number of bytes written (may be less than aCount)
        ///
        /// @throws NS_BASE_STREAM_WOULD_BLOCK if writing to the output stream would
        /// block the calling thread (non-blocking mode only)
        /// @throws <other-error> on failure
        ///
        /// NOTE: This method is defined by this interface in order to allow the
        /// output stream to efficiently copy the data from the input stream into
        /// its internal buffer (if any). If this method was provided as an external
        /// facility, a separate char* buffer would need to be used in order to call
        /// the output stream's other Write method.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new uint WriteFrom([MarshalAs(UnmanagedType.Interface)] nsIInputStream aFromStream, uint aCount);
		
		/// <summary>
        /// Low-level write method that has access to the stream's underlying buffer.
        /// The reader function may be called multiple times for segmented buffers.
        /// WriteSegments is expected to keep calling the reader until either there
        /// is nothing left to write or the reader returns an error.  WriteSegments
        /// should not call the reader with zero bytes to provide.
        ///
        /// @param aReader the "provider" of the data to be written
        /// @param aClosure opaque parameter passed to reader
        /// @param aCount the maximum number of bytes to be written
        ///
        /// @return number of bytes written (may be less than aCount)
        ///
        /// @throws NS_BASE_STREAM_WOULD_BLOCK if writing to the output stream would
        /// block the calling thread (non-blocking mode only)
        /// @throws NS_ERROR_NOT_IMPLEMENTED if the stream has no underlying buffer
        /// @throws <other-error> on failure
        ///
        /// NOTE: this function may be unimplemented if a stream has no underlying
        /// buffer (e.g., socket output stream).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new uint WriteSegments(System.IntPtr aReader, System.IntPtr aClosure, uint aCount);
		
		/// <summary>
        /// @return true if stream is non-blocking
        ///
        /// NOTE: writing to a blocking output stream will block the calling thread
        /// until all given data can be consumed by the stream.
        ///
        /// NOTE: a non-blocking output stream may implement nsIAsyncOutputStream to
        /// provide consumers with a way to wait for the stream to accept more data
        /// once its write method is unable to accept any data without blocking.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool IsNonBlocking();
		
		/// <summary>
        /// This method closes the stream and sets its internal status.  If the
        /// stream is already closed, then this method is ignored.  Once the stream
        /// is closed, the stream's status cannot be changed.  Any successful status
        /// code passed to this method is treated as NS_BASE_STREAM_CLOSED, which
        /// is equivalent to nsIInputStream::close.
        ///
        /// NOTE: this method exists in part to support pipes, which have both an
        /// input end and an output end.  If the output end of a pipe is closed, then
        /// reads from the input end of the pipe will fail.  The error code returned
        /// when an attempt is made to read from a "closed" pipe corresponds to the
        /// status code passed in when the output end of the pipe is closed, which
        /// greatly simplifies working with pipes in some cases.
        ///
        /// @param aStatus
        /// The error that will be reported if this stream is accessed after
        /// it has been closed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CloseWithStatus(int reason);
		
		/// <summary>
        /// Asynchronously wait for the stream to be writable or closed.  The
        /// notification is one-shot, meaning that each asyncWait call will result
        /// in exactly one notification callback.  After the OnOutputStreamReady event
        /// is dispatched, the stream releases its reference to the
        /// nsIOutputStreamCallback object.  It is safe to call asyncWait again from the
        /// notification handler.
        ///
        /// This method may be called at any time (even if write has not been called).
        /// In other words, this method may be called when the stream already has
        /// room for more data.  It may also be called when the stream is closed.  If
        /// the stream is already writable or closed when AsyncWait is called, then the
        /// OnOutputStreamReady event will be dispatched immediately.  Otherwise, the
        /// event will be dispatched when the stream becomes writable or closed.
        ///
        /// @param aCallback
        /// This object is notified when the stream becomes ready.  This
        /// parameter may be null to clear an existing callback.
        /// @param aFlags
        /// This parameter specifies optional flags passed in to configure
        /// the behavior of this method.  Pass zero to specify no flags.
        /// @param aRequestedCount
        /// Wait until at least this many bytes can be written.  This is only
        /// a suggestion to the underlying stream; it may be ignored.  The
        /// caller may pass zero to indicate no preference.
        /// @param aEventTarget
        /// Specify NULL to receive notification on ANY thread (possibly even
        /// recursively on the calling thread -- i.e., synchronously), or
        /// specify that the notification be delivered to a specific event
        /// target.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AsyncWait([MarshalAs(UnmanagedType.Interface)] nsIOutputStreamCallback aCallback, uint aFlags, uint aRequestedCount, [MarshalAs(UnmanagedType.Interface)] nsIEventTarget aEventTarget);
	}
	
	/// <summary>nsIAsyncOutputStreamConsts </summary>
	public class nsIAsyncOutputStreamConsts
	{
		
		// <summary>
        // If passed to asyncWait, this flag overrides the default behavior,
        // causing the OnOutputStreamReady notification to be suppressed until the
        // stream becomes closed (either as a result of closeWithStatus/close being
        // called on the stream or possibly due to some error in the underlying
        // stream).
        // </summary>
		public const ulong WAIT_CLOSURE_ONLY = (1<<0);
	}
	
	/// <summary>
    /// This is a companion interface for nsIAsyncOutputStream::asyncWait.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("40dbcdff-9053-42c5-a57c-3ec910d0f148")]
	public interface nsIOutputStreamCallback
	{
		
		/// <summary>
        /// Called to indicate that the stream is either writable or closed.
        ///
        /// @param aStream
        /// The stream whose asyncWait method was called.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnOutputStreamReady([MarshalAs(UnmanagedType.Interface)] nsIAsyncOutputStream aStream);
	}
}
