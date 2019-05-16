using Adresar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class PersonAddressViewModel : BaseViewModel
    {
        private readonly AdresarDatabase database;
        public PersonAddressViewModel(PersonAddress personAddress)
        {
            database = new AdresarDatabase();

            Cities = database.Cities.FindAll().ToList();

            Address = personAddress ?? new PersonAddress();

            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        private async void Save()
        {
            MessagingCenter.Send(this, "NewPersonAdress", Address);
            await Navigation.PopModalAsync();
        }

        private async void Delete()
        {
            await Navigation.PopModalAsync();
        }

        private List<City> _cities;
        public List<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }

        private PersonAddress _address;
        public PersonAddress Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
    }
}
