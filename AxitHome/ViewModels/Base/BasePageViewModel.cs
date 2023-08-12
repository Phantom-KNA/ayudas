using AxitHome.Helpers;
using AxitHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxitHome.ViewModels.Base
{
    public class BasePageViewModel : ObservableObject, IBasePageViewModel
    {
        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }
    }
}
