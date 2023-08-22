using System.Collections.ObjectModel;
using System.Windows.Input;
using AxitHome.Models;
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
            //Crear el listado de mascotas
            List<Pet> pets = new List<Pet>
            {
                new Pet
                {
                    Name = "Max",
                    Age = 5,
                    Image = "https://img.freepik.com/free-photo/isolated-happy-smiling-dog-white-background-portrait-4_1562-693.jpg?w=826&t=st=1692667635~exp=1692668235~hmac=0deb8da73424920dfa2506753763da855da3670ccf7a5bb55c321bdd9a8fe694"
                },
                new Pet
                {
                    Name = "Rocky",
                    Age = 2,
                    Image = "https://img.freepik.com/free-photo/isolated-happy-smiling-dog-white-background-portrait-4_1562-693.jpg?w=826&t=st=1692667635~exp=1692668235~hmac=0deb8da73424920dfa2506753763da855da3670ccf7a5bb55c321bdd9a8fe694"
                },
                new Pet
                {
                    Name = "Mia",
                    Age = 9,
                    Image = "https://img.freepik.com/free-photo/isolated-happy-smiling-dog-white-background-portrait-4_1562-693.jpg?w=826&t=st=1692667635~exp=1692668235~hmac=0deb8da73424920dfa2506753763da855da3670ccf7a5bb55c321bdd9a8fe694"
                },
                new Pet
                {
                    Name = "Pepito",
                    Age = 3,
                    Image = "https://img.freepik.com/free-photo/isolated-happy-smiling-dog-white-background-portrait-4_1562-693.jpg?w=826&t=st=1692667635~exp=1692668235~hmac=0deb8da73424920dfa2506753763da855da3670ccf7a5bb55c321bdd9a8fe694"
                },
                new Pet
                {
                    Name = "Ladron",
                    Age = 8,
                    Image = "https://img.freepik.com/free-photo/isolated-happy-smiling-dog-white-background-portrait-4_1562-693.jpg?w=826&t=st=1692667635~exp=1692668235~hmac=0deb8da73424920dfa2506753763da855da3670ccf7a5bb55c321bdd9a8fe694"
                },
                new Pet
                {
                    Name = "Barr",
                    Age = 2,
                    Image = "https://img.freepik.com/free-photo/isolated-happy-smiling-dog-white-background-portrait-4_1562-693.jpg?w=826&t=st=1692667635~exp=1692668235~hmac=0deb8da73424920dfa2506753763da855da3670ccf7a5bb55c321bdd9a8fe694"
                },
                new Pet
                {
                    Name = "Motica",
                    Age = 5,
                    Image = "https://img.freepik.com/free-photo/isolated-happy-smiling-dog-white-background-portrait-4_1562-693.jpg?w=826&t=st=1692667635~exp=1692668235~hmac=0deb8da73424920dfa2506753763da855da3670ccf7a5bb55c321bdd9a8fe694"
                }
            };
            //A;adir a ObsevableCollection
            Pets = new ObservableCollection<Pet>(pets);
        }

        #region Propiedades
        ObservableCollection<Pet> listPets;
        public ObservableCollection<Pet> Pets
        {
            get { return listPets; }
            set { SetProperty(ref listPets, value); }
        }
        #endregion


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
