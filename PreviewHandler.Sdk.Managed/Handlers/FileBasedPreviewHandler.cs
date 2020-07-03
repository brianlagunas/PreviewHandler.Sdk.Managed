using PreviewHandler.Sdk.Interop;
using System.Runtime.InteropServices;

namespace PreviewHandler.Sdk.Handlers
{
    /// <summary>
    /// Extends the <see cref="PreviewHandlerBase" /> by implementing IInitializeWithFile.
    /// </summary>
    public abstract class FileBasedPreviewHandler : PreviewHandlerBase, IInitializeWithFile
    {
        /// <summary>
        /// Gets the file path.
        /// </summary>
        public string FilePath { get; private set; }

        /// <inheritdoc />
        public void Initialize([MarshalAs(UnmanagedType.LPWStr)] string pszFilePath, uint grfMode)
        {
            // Ignore the grfMode always use read mode to access the file.
            FilePath = pszFilePath;
        }
    }
}
