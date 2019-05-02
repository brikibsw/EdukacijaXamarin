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
        private readonly AdresarDatabase database;
        public CityPageViewModel(City grad)
        {
            database = new AdresarDatabase();

            if(grad == null)
            {
                City = new City();
            }
            else
            {
                City = grad;
            }

            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);
        }

        public ICommand SaveCommand { get; private set; }
        public void Save()
        {
            // spremimo City ako je novi
            if( City.Id == 0)
            {
                database.Cities.Insert(City);
            }
            // ili ažuriramo ako je postojeci
            else
            {
                database.Cities.Update(City);
            }

            // vratimo se na popis gradova CityList
            Navigation.PopAsync();
        }

        public ICommand DeleteCommand { get; private set; }

        private void Delete()
        {
            // ako je postojeci grad obrisati ga iz baze
            if(City.Id != 0)
            {
                database.Cities.Delete(a => a.Id == City.Id);
            }

            // vratimo se na popis gradova CityList
            Navigation.PopAsync();
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
