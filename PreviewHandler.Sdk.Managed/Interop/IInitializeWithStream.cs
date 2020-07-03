using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace PreviewHandler.Sdk.Interop
{
    /// <summary>
    /// Exposes a method that initializes a handler, such as a property handler, thumbnail handler, or preview handler, with a stream.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f")]
    public interface IInitializeWithStream
    {
        /// <summary>
        /// Initializes a handler with a stream.
        /// </summary>
        /// <param name="pstream">A pointer to an <see cref="IStream" /> interface that represents the stream source.</param>
        /// <param name="grfMode">One of the <see href="https://docs.microsoft.com/en-us/windows/win32/stg/stgm-constants" >STGM</see> values that indicates the access mode for <paramref name="pstream"/>.</param>
        void Initialize(IStream pstream, uint grfMode);
    }
}
