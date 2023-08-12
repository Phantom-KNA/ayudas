using AxitHome.ViewModels;

namespace AxitHome.Views.Pages;

public partial class LoginPage : ContentPage
{
    private readonly LoginPageViewModel _viewModel;
    public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = loginPageViewModel;
    }
}