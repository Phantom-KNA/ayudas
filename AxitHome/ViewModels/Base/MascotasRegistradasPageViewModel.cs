using System.Windows.Input;
using AxitHome.ViewModels.Base;
using Microsoft.Maui.Controls;

namespace AxitHome.ViewModels
{
    public class MascotasRegistradasPageViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; private set; }

        public MascotasRegistradasPageViewModel()
        {
            GoBackCommand = new Command(GoBack);
        }

        private void GoBack()
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                Shell.Current.Navigation.PopAsync();
            }
            else
            {
                Shell.Current.GoToAsync("//Inicio");  
            }
        }
    }
}
