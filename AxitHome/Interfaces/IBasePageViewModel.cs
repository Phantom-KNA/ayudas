using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxitHome.Interfaces
{
    public interface IBasePageViewModel : INotifyPropertyChanged
    {
        Task OnAppearing();
        Task OnDisappearing();
    }
}
