using VAST_Survey_Tool.Services;
using Xamarin.Forms;

namespace VAST_Survey_Tool
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<VASTDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
