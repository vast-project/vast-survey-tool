using System;
using System.Collections.Generic;
using System.ComponentModel;
using VAST_Survey_Tool.Models;
using VAST_Survey_Tool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VAST_Survey_Tool.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}