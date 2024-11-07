using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FerruzFlixMAUI.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public IRelayCommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new AsyncRelayCommand(OnLogin);
        }

        private async Task OnLogin()
        {
            if (IsValidUser(Username, Password))
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            var validUsers = new Dictionary<string, string>
            {
                { "Ferruzca", "2812" },
                { "Jade", "0201" }
            };

            return validUsers.TryGetValue(username, out var validPassword) && validPassword == password;
        }
    }
}

