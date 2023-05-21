using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class UserModel
    {

        public List<ContentListItem> Watchlist { get; set; } = new List<ContentListItem>();
        public List<ContentListItem> Favorites { get; set; } = new List<ContentListItem>();

        private static UserModel instance;
        private UserModel()
        {
            LoadFavorites();
            LoadWatchlist();
        }

        public static UserModel Instance
        {
            get
            {
                if (instance is null)
                    instance = new UserModel();

                return instance;
            }
        }
        public async static Task<UserModel> GetInstanceAsync()
        {
            if (instance is null)
                instance = await BuildViewModelAsync();
            return instance;

        }

        async public static Task<UserModel> BuildViewModelAsync()
        {
            return new UserModel();
        }

        public async Task LoadWatchlist()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            bool fileExists = await storageFolder.FileExistsAsync("watchlist.json");
            if (fileExists == false)
            {
                await storageFolder.CreateFileAsync("watchlist.json");
            }
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("watchlist.json");
            if (file == null)
                return;

            string text = await Windows.Storage.FileIO.ReadTextAsync(file);
            Watchlist = JsonConvert.DeserializeObject<List<ContentListItem>>(text) ?? new List<ContentListItem>();
        }

        public async Task LoadFavorites()
        {

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            bool fileExists = await storageFolder.FileExistsAsync("favorites.json");
            if (fileExists == false)
            {

                await storageFolder.CreateFileAsync("favorites.json");
            }

            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("favorites.json");
            if (file == null)
                return;

            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            Favorites = JsonConvert.DeserializeObject<List<ContentListItem>>(text) ?? new List<ContentListItem>();


        }

        public async Task AddContentToWatchlist(ContentListItem item)
        {

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            if (Watchlist.Count == 0)
            {
                await storageFolder.CreateFileAsync("watchlist.json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            }
            try
            {
                Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("watchlist.json");
                if (file == null)
                    return;

                Watchlist.Add(item);
                string json = JsonConvert.SerializeObject(Watchlist);
                await Windows.Storage.FileIO.WriteTextAsync(file, json);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task AddContentToFavorites(ContentListItem item)
        {

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            if (Favorites.Count == 0)
            {
                await storageFolder.CreateFileAsync("favorites.json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            }
            try
            {
                Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("favorites.json");
                if (file == null)
                    return;

                Favorites.Add(item);
                string json = JsonConvert.SerializeObject(Favorites);
                await Windows.Storage.FileIO.WriteTextAsync(file, json);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task RemoveContentFromWatchlist(ContentListItem item)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            if (Watchlist.Count == 0)
            {
                return;
            }
            try
            {
                Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("watchlist.json");
                if (file == null)
                    return;

                Watchlist.Remove(item);
                string json = JsonConvert.SerializeObject(Watchlist);
                await Windows.Storage.FileIO.WriteTextAsync(file, json);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task RemoveContentFromFavorites(ContentListItem item)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            if (Favorites.Count == 0)
            {
                return;
            }
            try
            {
                Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("favorites.json");
                if (file == null)
                    return;

                Favorites.Remove(item);
                string json = JsonConvert.SerializeObject(Favorites);
                await Windows.Storage.FileIO.WriteTextAsync(file, json);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
