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
    public class CreateAccountViewModel : BaseViewModel
    {
        #region Commnad

        public ICommand GoLogin { get; set; }

        #endregion

        #region Constructor

        public CreateAccountViewModel()
        {
            GoLogin = new Command(async () => await GoToLogin());
        }

        #endregion

        #region Private Methods
        private async Task GoToLogin()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        #endregion
    }
}
