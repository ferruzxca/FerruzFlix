using Microsoft.Maui.Controls;
using System;
using FerruzFlixMAUI.ViewModels;

namespace FerruzFlixMAUI.Pages
{
    public partial class SearchPage : ContentPage
    {
        private readonly SearchViewModel _searchViewModel;

        public SearchPage(SearchViewModel searchViewModel)
        {
            InitializeComponent();
            _searchViewModel = searchViewModel;
            BindingContext = _searchViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //await _searchViewModel.InitializeAsync();
        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
