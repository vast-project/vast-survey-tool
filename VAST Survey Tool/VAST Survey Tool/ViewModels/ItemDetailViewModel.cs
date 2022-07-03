using System;
using System.Diagnostics;
using System.Threading.Tasks;
using VAST_Survey_Tool.Models;
using Xamarin.Forms;

namespace VAST_Survey_Tool.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string title;
        private string description;
        private string url;
        private string imageURL;
        public string Id { get; set; }

        public new string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string URL
        {
            get => url;
            set => SetProperty(ref url, value);
        }

        public string ImageURL
        {
            get => imageURL;
            set => SetProperty(ref imageURL, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Title = item.Title;
                Description = item.Description;
                ImageURL = item.ImageURL;
                URL = item.URL;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
