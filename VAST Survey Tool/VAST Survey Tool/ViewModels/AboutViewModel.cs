using System.Windows.Input;
using VAST_Survey_Tool.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VAST_Survey_Tool.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = AppResources.About;
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.vast-project.eu/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}