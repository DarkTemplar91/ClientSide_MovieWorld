using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieWorld.ViewModels
{
    public class MovieDetailsViewModel : ObservableRecipient
    {
        public MovieDetailsViewModel()
        {
            ReloadTaskCommand = new RelayCommand(OnNavigatedAsync);
        }
        private int movieId;
        public int MovieId { get { return movieId; } set { movieId = value; } }
        private MovieModel movieModel;
        public MovieModel MovieModel
        {
            get { return movieModel; }
            set { SetProperty(ref movieModel, value); }
        }

        private MovieCastModel movieCastModel;
        public MovieCastModel MovieCastModel
        {
            get { return movieCastModel; }
            set { SetProperty(ref movieCastModel, value); }
        }

        public ICommand ReloadTaskCommand { get; }

        public async void OnNavigatedAsync()
        {
            //TODO: Create a singleton?
            var service = new MovieDBService();
            MovieModel = await service.GetMovieModelAsync(movieId);
            MovieCastModel = await service.GetMovieCastAsync(movieId);

        }

        

    }
}
