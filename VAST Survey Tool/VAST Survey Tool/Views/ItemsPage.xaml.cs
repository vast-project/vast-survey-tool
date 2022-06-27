using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAST_Survey_Tool.Models;
using VAST_Survey_Tool.ViewModels;
using VAST_Survey_Tool.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VAST_Survey_Tool.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}