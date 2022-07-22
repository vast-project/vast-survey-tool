using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using VAST_Survey_Tool.Models;
using VAST_Survey_Tool.Models.Media;
using VAST_Survey_Tool.Models.Post;
using Xamarin.Essentials;

namespace VAST_Survey_Tool.Services
{
    public class VASTDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        private const string _url = "https://platform.vast-project.eu/wp-json/wp/v2/posts?categories=22";
        // This handles the Web data request
        private HttpClient _client = new HttpClient();
        private bool _itemsLoaded = false;

        public VASTDataStore()
        {
            items = new List<Item>();
            /*items = new List<Item>()
            {
                new Item {
                    Id = System.Guid.NewGuid().ToString(),
                    Title = "Αντιγόνη του Σοφοκλή - Αλέξανδρος Ραπτοτάσιος",
                    Description = "Μια παράσταση για τη σχέση της πόλης / των πολιτών με την εξουσία, διαχρονικό ζήτημα του τραγικού έργου.",
                    URL= "https://platform.vast-project.eu/mobile-antigone-july-2022/"
                },
            };*/
            _itemsLoaded = false;
            OnGetList();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (!_itemsLoaded)
            {
                await OnGetList();
            }
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (!_itemsLoaded || forceRefresh == true)
            {
                await OnGetList();
            }
            return await Task.FromResult(items);
        }

        protected async Task<string> GetImageURLForMedia(Post post)
        {
            string url = null;
            if (post.featured_media != 0)
            {
                try
                {
                    var content = await _client.GetStringAsync(post._links.FeaturedMedia[0].href.ToString());
                    // Debug.WriteLine("Content: " + content.ToString());
                    var media = JsonSerializer.Deserialize<Media>(content);
                    url = media.source_url.ToString();
                }
                catch (Exception ey)
                {
                    Debug.WriteLine("Media: " + post._links.FeaturedMedia[0].href.ToString());
                    Debug.WriteLine("" + ey);
                }
            }
            return await Task.FromResult(url);
        }
        protected async Task<bool> OnGetList()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {

                try
                {
                    // Getting JSON data from the Web
                    var content = await _client.GetStringAsync(_url);

                    // We deserialize the JSON data
                    var posts = JsonSerializer.Deserialize<List<Post>>(content);
                    // Convert posts to items...
                    
                    var itemList = await Task.WhenAll(posts.Select(async (i) => new Item
                    {
                        Id = i.id.ToString(),
                        Title = i.title.rendered.ToString(),
                        TitleDecoded = HttpUtility.HtmlDecode(i.title.rendered.ToString()),
                        Description = i.excerpt.rendered.ToString(),
                        URL = !i.PostMetaFields.wpforms_conversationalform_url.Any() ? i.link.ToString() : i.PostMetaFields.wpforms_conversationalform_url[0].ToString(),
                        ImageURL = await GetImageURLForMedia(i),
                    }));
                    items.Clear();
                    items.AddRange(itemList.ToList());
                    _itemsLoaded = true;
                    /*foreach (var i in items)
                    {
                        // Console.WriteLine("Element = {0}", i.ToString());
                        Debug.WriteLine("Element = {0} {1} {2}", i.ToString(), i.Title, i.Id);
                    }*/
                    return await Task.FromResult(true);
                }
                catch (Exception ey)
                {
                    Debug.WriteLine("" + ey);
                }
                return await Task.FromResult(false);
            }
            return await Task.FromResult(false);
        }

    }
}