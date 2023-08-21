using AxitHome.ViewModels;
using Microsoft.Maui.Controls;

namespace AxitHome.Views.Pages
{
    public partial class MascotasRegistradasPage : ContentPage
    {
        public MascotasRegistradasPage()
        {
            InitializeComponent();
            BindingContext = new MascotasRegistradasPageViewModel();
        }
    }
}
