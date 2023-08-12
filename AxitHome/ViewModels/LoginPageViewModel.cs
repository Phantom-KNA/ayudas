using AxitHome.ViewModels.Base;
using AxitHome.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AxitHome.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {

        #region Commnad

        public ICommand IngresarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }

        #endregion

        #region Constructor

        public LoginPageViewModel()
        {
            IngresarCommand = new Command(async () => await Ingresar());
            RegistrarCommand = new Command(async () => await Registrar());
        }

        #endregion

        #region Private Methods
        private async Task Registrar()
        {
            await Shell.Current.GoToAsync(nameof(CreateAccountPage));
        }

        private async Task Ingresar()
        {
            await Shell.Current.GoToAsync(nameof(HomePage));

        }

        #endregion
    }
}
