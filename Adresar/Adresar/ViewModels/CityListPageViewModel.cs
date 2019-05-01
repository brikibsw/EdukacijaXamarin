using Adresar.Data;
using Adresar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class CityListPageViewModel : BaseViewModel
    {
        private readonly AdresarDatabase database;

        public CityListPageViewModel()
        {
            database = new AdresarDatabase();
            NewCityCommand = new Command(NewCity);
            DeleteCityCommand = new Command<City>(async (c) => await DeleteCity(c));
            SortByNameCommand = new Command(SortyByName);
            SortByZipCodeCommand = new Command(SortyByZipCode);
        }

        public ICommand SortByNameCommand { get; }

        private void SortyByName()
        {
            Cities = new ObservableCollection<City>(Cities.OrderBy(a => a.Name));
        }

        public ICommand SortByZipCodeCommand { get; }

        private void SortyByZipCode()
        {
            Cities = new ObservableCollection<City>(Cities.OrderBy(a => a.ZipCode));
        }

        public ICommand NewCityCommand { get; }


        public async void NewCity()
        {
            await Navigation.PushAsync(new CityPage());
        }

        public ICommand DeleteCityCommand { get; }

        public async Task DeleteCity(City city)
        {
            var answer = await DisplayAlert("Brisanje", "Da li ste sigurni da želite obrisati grad?", "Da", "Ne");
            if( answer )
            {
                database.Cities.Delete(a => a.Id == city.Id);
                await Task.Factory.StartNew(() => LoadCities());
            }
        }

        public void LoadCities()
        {
            Loading = true;
            Cities = new ObservableCollection<City>(database.Cities.FindAll());
            Loading = false;
        }

        private ObservableCollection<City> cities;

        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set
            {
                cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
                if( value != null )
                {
                    EditCity();
                }
            }
        }

        private async void EditCity()
        {
            var res = await DisplayAlert("Editiranje", $"Da li želite aditirati {SelectedCity.Name} ?", "Da", "Ne");
            if( res )
            {
                await Navigation.PushAsync(new CityPage(SelectedCity));
            }
            else
            {
                SelectedCity = null;
            }
        }

        private bool loading;

        public bool Loading
        {
            get { return loading; }
            set { loading = value; OnPropertyChanged(nameof(Loading)); }
        }

    }
}
