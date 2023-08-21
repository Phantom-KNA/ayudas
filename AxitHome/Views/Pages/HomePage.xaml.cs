using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace AxitHome.Views.Pages
{
    public partial class HomePage : ContentPage
    {
        public ICommand NavigateToMascotasCommand { get; set; }

        public HomePage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, true);

            // Inicializa el comando
            NavigateToMascotasCommand = new Command(async () => await NavigateToMascotas());
            BindingContext = this; // Establece el contexto de enlace a la página misma.
        }

        private async Task NavigateToMascotas()
        {
            await Shell.Current.GoToAsync("//MascotasRegistradasPage");
        }
    }
}
