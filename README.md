PreviewHandler.Sdk.Managed

## Create a PreviewHandlerControl

```
 public class DemoPreviewHandlerControl : PreviewHandlerControlBase
    {
        public override void DoPreview<T>(T dataSource)
        {
            if (!(dataSource is IStream previewStream))
                throw new ArgumentException($"{nameof(dataSource)} for {nameof(DemoPreviewHandlerControl)} must be a stream but was a '{typeof(T)}'");

            this.InvokeOnControlThread(() =>
            {
                //TODO: handle incoming stream
                var stream = new PreviewStream(previewStream);

                var tb = new TextBox() { Text = "Your UI Goes Here!" };
                Controls.Add(tb);
            });
            
            base.DoPreview(dataSource); //sets this.Visible = true
        }
    }
```

## Create Preview Handler

```    
    [PreviewHandler("Demo Preview Handler", ".ext", "{D7D0D432-6ADA-407A-B959-5459CC24A723}")]
    [ProgId("Demo.PreviewHandler")]
    [Guid("16519EC8-6723-459D-984C-0CCC706B9778")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public sealed class DemoPreviewHandler : StreamBasedPreviewHandler
    {
        DemoPreviewHandlerControl _control;

        public override void DoPreview()
        {
            _control.DoPreview(Stream);
        }

        protected override IPreviewHandlerControl CreatePreviewHandlerControl()
        {
            _control = new DemoPreviewHandlerControl();
            return _control;
        }
    }

```
_Note: GUIDs should be unique._

## Create Installer

```
    [RunInstaller(true)]
    public class ComInstaller : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            try
            {
                base.Install(stateSaver);
                RegistrationServices regsrv = new RegistrationServices();
                if (!regsrv.RegisterAssembly(this.GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase))
                {
                    throw new InstallException("Failed to register for COM interop.");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                throw;
            }
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            RegistrationServices regsrv = new RegistrationServices();
            if (!regsrv.UnregisterAssembly(this.GetType().Assembly))
            {
                throw new InstallException("Failed to unregister for COM interop.");
            }
        }
    }
```

## Create Registration

```
    internal static class Registration
    {
        [ComRegisterFunction]
        private static void Register(Type t) { PreviewHandlerBase.Register(t); }

        [ComUnregisterFunction]
        private static void Unregister(Type t) { PreviewHandlerBase.Unregister(t); }
    }
```

## Install Preview Handler

```
gacutil -i DemoPreviewHandler.dll (optional gac registration)
regasm /codebase DemoPreviewHandler.dll
```

## Uninstall Preview Handler
```
regasm /unregister DemoPreviewHandler.dll
gacutil -u DemoPreviewHandler (optional gac unregistration)
```

Note: For x64 systems make sure you use `C:\Windows\Microsoft.NET\Framework64\v4.0.30319\regasm.exe`
