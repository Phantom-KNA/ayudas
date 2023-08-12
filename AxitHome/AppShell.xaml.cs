using AxitHome.Views.Pages;

namespace AxitHome;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
	}

    private void RegisterRoutes()
    {
        Routing.RegisterRoute("CreateAccountPage", typeof(CreateAccountPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}
