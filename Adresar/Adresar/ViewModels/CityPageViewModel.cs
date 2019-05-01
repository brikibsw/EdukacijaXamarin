using Adresar.Data;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class CityPageViewModel : BaseViewModel
    {
        private readonly AdresarDatabase database;

        public CityPageViewModel()
        {
            database = new AdresarDatabase();
            if( City == null )
            {
                City = new City();
            }

            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);
        }

        public ICommand SaveCommand { get; private set; }
        public void Save()
        {
            // spremimo City negdje
            database.Cities.Insert(City);


            // vratimo se na popis gradova CityList
            Navigation.PopAsync();
        }

        public ICommand DeleteCommand { get; private set; }

        private async void Delete()
        {
            if( City.Id > 0 )
            {
                var answer = await DisplayAlert("Brisanje", "Da li ste sigurni da želite obrisati grad?", "Da", "Ne");
                if(answer)
                {
                    database.Cities.Delete(a => a.Id == City.Id);
                }
            }

            //City = new City();
            await Navigation.PopAsync();
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

        public override void Dispose()
        {
            if( database != null )
            {
                database.Dispose();
            }

            base.Dispose();
        }
    }
}
