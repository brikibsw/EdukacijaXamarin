using Adresar.Data;
using Adresar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            SortByNameCommand = new Command(SortByName);
            SortByZipCommand = new Command(SortByZip);

            LoadCities();
        }

        public void LoadCities()
        {
            originalGradovi = database.Cities.FindAll().ToList();
            Gradovi = new List<City>(originalGradovi);
        }

        private List<City> originalGradovi { get; set; }

        public ICommand NewCityCommand { get; }

        private async void NewCity()
        {
            await Navigation.PushAsync(new CityPage());
        }

        public ICommand SortByNameCommand { get; }

        private string nameSort = "ASC";

        private void SortByName()
        {
            if(nameSort == "ASC")
            {
                Gradovi = new List<City>(Gradovi.OrderBy(a => a.Name));
                nameSort = "DESC";
            }
            else
            {
                Gradovi = new List<City>(Gradovi.OrderByDescending(a => a.Name));
                nameSort = "ASC";
            }
        }

        public ICommand SortByZipCommand { get; }

        private string zipSort = "ASC";

        private void SortByZip()
        {
            if (zipSort == "ASC")
            {
                Gradovi = new List<City>(Gradovi.OrderBy(a => a.ZipCode));
                zipSort = "DESC";
            }
            else
            {
                Gradovi = new List<City>(Gradovi.OrderByDescending(a => a.ZipCode));
                zipSort = "ASC";
            }
        }

        private List<City> _gradovi;
        public List<City> Gradovi
        {
            get { return _gradovi;  }
            set
            {
                _gradovi = value;
                OnPropertyChanged(nameof(Gradovi));
            }
        }

        private City _grad;

        public City Grad
        {
            get { return _grad; }
            set
            {
                _grad = value;
                OnPropertyChanged(nameof(Grad));
                NavigateToCityPage();
            }
        }

        private async void NavigateToCityPage()
        {
            await Navigation.PushAsync(new CityPage(Grad));
        }

        private string _search;

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                OnSearch();
            }
        }

        private void OnSearch()
        {
            if(Search != null && Search.Length > 0)
            {
                var result = originalGradovi.Where(a => 
                    a.Name.ToUpper().StartsWith(Search.ToUpper()) ||
                    a.ZipCode.ToString().StartsWith(Search)
                );
                Gradovi = new List<City>(result);
            }
            else
            {
                Gradovi = new List<City>(originalGradovi);
            }
        }
    }
}
