using Milo.Core;

namespace Milo.Encoding
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
            MiloCore.Start();
            base.OnStart();
        }
    }
}