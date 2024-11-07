using FerruzFlixMAUI.Pages;

namespace FerruzFlixMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
		
		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));

        Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

        this.CurrentItem = new ShellContent { Content = new LoginPage() };

    }
}
