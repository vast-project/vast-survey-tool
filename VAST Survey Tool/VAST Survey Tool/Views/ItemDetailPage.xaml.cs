using VAST_Survey_Tool.ViewModels;
using Xamarin.Forms;

namespace VAST_Survey_Tool.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}