using Adresar.Data;
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
        public async void Save()
        {
            if(City.Name == null || City.Name.Length == 0 || City.ZipCode == 0 )
            {
                await DisplayAlert("Upozorenje", "Vrijednosti naziva i poštanskog broja moraju biti unešeni!", "OK");
            }
            else
            {
                var postoji = database.Cities.Exists(a => a.Name.ToUpper() == City.Name.ToUpper() && 
                                                            a.ZipCode == City.ZipCode);
                if( postoji )
                {
                    await DisplayAlert("Upozorenje", "Grad sa istim imenom i poštanskim brojem već postoji!", "OK");
                }
                else
                {
                    // spremimo City ako je novi
                    if (City.Id == 0)
                    {
                        database.Cities.Insert(City);
                    }
                    // ili ažuriramo ako je postojeci
                    else
                    {
                        database.Cities.Update(City);
                    }

                    // vratimo se na popis gradova CityList
                    await Navigation.PopAsync();
                }
            }
        }

        public ICommand DeleteCommand { get; private set; }

        private async void Delete()
        {
            // pitati korisnika da li je siguran da zeli obrsati grad

            var result = await DisplayAlert("Brisanje",
                                            "Jeste li ste sigurni da želite obrisati grad?", 
                                            "Da", 
                                            "Ne");

            if( result )
            {
                // ako je postojeci grad obrisati ga iz baze
                if (City.Id != 0)
                {
                    database.Cities.Delete( (a) => a.Id == City.Id );
                }

                // vratimo se na popis gradova CityList
                await Navigation.PopAsync();
            }
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
