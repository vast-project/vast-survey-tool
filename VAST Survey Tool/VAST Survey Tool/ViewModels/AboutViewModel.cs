using System.Windows.Input;
using VAST_Survey_Tool.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VAST_Survey_Tool.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private const string File = "vast_logo.png";

        public AboutViewModel()
        {
            Title = AppResources.About;
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.vast-project.eu/"));
            /*VASTLogo = new Image { };
            VASTLogo.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("vast_logo.xml")
                : ImageSource.FromFile(File);*/
        }

        public ICommand OpenWebCommand { get; }
        // public Image VASTLogo { get; }
    }
}