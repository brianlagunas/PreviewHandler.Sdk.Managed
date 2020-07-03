using PreviewHandler.Sdk.Interop;
using System.Runtime.InteropServices.ComTypes;

namespace PreviewHandler.Sdk.Handlers
{
    /// <summary>
    /// Extends the <see cref="PreviewHandlerBase" /> by implementing IInitializeWithStream.
    /// </summary>
    public abstract class StreamBasedPreviewHandler : PreviewHandlerBase, IInitializeWithStream
    {
        /// <summary>
        /// Gets the stream object to access file.
        /// </summary>
        public IStream Stream { get; private set; }

        /// <inheritdoc/>
        public void Initialize(IStream pstream, uint grfMode)
        {
            // Ignore the grfMode always use read mode to access the file.
            Stream = pstream;
        }
    }
}
