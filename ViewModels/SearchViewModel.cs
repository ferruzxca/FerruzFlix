using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FerruzFlixMAUI.Models;
using FerruzFlixMAUI.Pages;
using FerruzFlixMAUI.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace FerruzFlixMAUI.ViewModels
{
    public class SearchViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;

        // Propiedad que contiene los resultados de búsqueda
        public ObservableCollection<Media> SearchResults { get; set; } = new ObservableCollection<Media>();

        // Comando de búsqueda que se activa al ingresar texto en el SearchBar
        public Command<string> SearchCommand { get; }

        // Comando para navegar a la página de detalles de la película seleccionada
        public IRelayCommand<Media> NavigateToDetailsCommand { get; }

        public SearchViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
            SearchCommand = new Command<string>(async (query) => await SearchMovies(query));
            NavigateToDetailsCommand = new RelayCommand<Media>(async (media) => await GoToDetailsPage(media));
        }

        // Método que realiza la búsqueda en la API
        private async Task SearchMovies(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return;

            var movies = await _tmdbService.SearchMoviesAsync(query);
            SearchResults.Clear();
            foreach (var movie in movies)
            {
                SearchResults.Add(movie);
            }
        }

        // Método que navega a la página de detalles con la película seleccionada
        private async Task GoToDetailsPage(Media media)
        {
            if (media == null)
                return;

            var parameters = new Dictionary<string, object>
            {
                { nameof(DetailsViewModel.Media), media }
            };

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, parameters);
        }
    }
}
