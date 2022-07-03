using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VAST_Survey_Tool.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Πληροφορίες";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}