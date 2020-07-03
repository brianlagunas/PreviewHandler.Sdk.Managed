using System;

namespace PreviewHandler.Sdk
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class PreviewHandlerAttribute : Attribute
    {
        public string DisplayName { get; private set; }
        public string Extension { get; private set; }
        public string AppId { get; private set; }

        public PreviewHandlerAttribute(string displayName, string extension, string appId)
        {
            if (displayName == null)
                throw new ArgumentNullException(nameof(displayName));

            if (extension == null)
                throw new ArgumentNullException(nameof(extension));

            if (appId == null)
                throw new ArgumentNullException(nameof(appId));
            
            DisplayName = displayName;
            Extension = extension;
            AppId = appId;
        }
    }
}
