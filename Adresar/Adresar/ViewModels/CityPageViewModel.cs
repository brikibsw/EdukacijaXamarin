using Adresar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class CityPageViewModel : BaseViewModel
    {
        public CityPageViewModel()
        {
            City = new City();

            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);
        }

        public ICommand SaveCommand { get; private set; }
        public void Save()
        {
            // spremimo City negdje

            // vratimo se na popis gradova CityList
            Navigation.PopAsync();
        }

        public ICommand DeleteCommand { get; private set; }

        private void Delete()
        {
            // ako je postojeci grad obrisati ga iz baze

            City = new City();
        }

        private City _city;
        public City City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
    }
}
