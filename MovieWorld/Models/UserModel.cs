using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    /// <summary>
    /// A User singleton that represents the current user of our application.
    /// Custom class due to the asycn builder.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// The list of movies added to the user's watchlist.
        /// </summary>
        public List<ContentListItem> Watchlist { get; private set; } = new();
        /// <summary>
        /// The list of movies added to the user's favorites.
        /// </summary>
        public List<ContentListItem> Favorites { get; private set; } = new();

        /// <summary>
        /// Singleton instance of the UserModel
        /// </summary>
        private static UserModel instance;
        /// <summary>
        /// Private constructor so the User can only be initialized by the application
        /// </summary>
        private UserModel()
        {
            LoadFavorites();
            LoadWatchlist();
        }

        /// <summary>
        /// Returns with an instance for the singleton
        /// </summary>
        public static UserModel Instance
        {
            get
            {
                instance ??= new UserModel();

                return instance;
            }
        }
        /// <summary>
        /// Async method that constructs a singleton <c>UserModel</c> asynchronously
        /// </summary>
        /// <returns></returns>
        public static async Task<UserModel> GetInstanceAsync()
        {
            instance ??= await BuildViewModelAsync();
            return instance;

        }
        /// <summary>
        /// Called by the asynchronous GetInstance method. Calls the constructor.
        /// </summary>
        /// <returns></returns>
        private static async Task<UserModel> BuildViewModelAsync()
        {
            return new UserModel();
        }

        /// <summary>
        /// Loads the list of content saved to the local cache as a JSON. These items are to be added to the watchlist of the user.
        /// </summary>
        /// <returns></returns>
        private async Task LoadWatchlist()
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
        /// <summary>
        /// Loads the list of content saved to the local caches. These items are to be added to the Favorites page.
        /// </summary>
        /// <returns></returns>
        private async Task LoadFavorites()
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
        /// <summary>
        /// Adds content to the Watchlist and overwrites the corresponding JSON file
        /// </summary>
        /// <param name="item">the <c>ContentListItem</c> to be added to the watchlist</param>
        /// <returns></returns>
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
        /// <summary>
        /// Adds content to the Favorites and overwrites the corresponding JSON file
        /// </summary>
        /// <param name="item">the <c>ContentListItem</c> to be added to the favorites</param>
        /// <returns></returns>
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
        /// <summary>
        /// Removes content From the Watchlist and overwrites the corresponding JSON file
        /// </summary>
        /// <param name="item">the <c>ContentListItem</c> to be removed from the watchlist</param>
        /// <returns></returns>
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
        /// <summary>
        /// Removes content from the Watchlist and overwrites the corresponding JSON file
        /// </summary>
        /// <param name="item">the <c>ContentListItem</c> to be removed from the favorites</param>
        /// <returns></returns>
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
