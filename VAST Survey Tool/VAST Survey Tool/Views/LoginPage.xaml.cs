using VAST_Survey_Tool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VAST_Survey_Tool.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}