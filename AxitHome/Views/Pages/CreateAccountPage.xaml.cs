using AxitHome.ViewModels;

namespace AxitHome.Views.Pages;

public partial class CreateAccountPage : ContentPage
{
    private readonly CreateAccountViewModel _viewModel;
    public CreateAccountPage(CreateAccountViewModel createAccountViewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = createAccountViewModel;
    }
}