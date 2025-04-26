using Milo.Core;
using Milo.Core.Services;

namespace Milo.Apps.Encoding.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override void OnStart()
        {
            var service = IPlatformApplication.Current?.Services.GetService<IMiloServiceManager>();
            if (service != null)
            {
                MiloCore.Start(service);
            }
            
            base.OnStart();
        }
    }
}