using Adresar.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private readonly AdresarDatabase database;
        public PersonViewModel()
        {
            database = new AdresarDatabase();

            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);

            GenderList = new List<string> { "M", "Ž" };
        }


        public ICommand SaveCommand { get; }
        public async void Save()
        {
            if (Person.Name == null || Person.Name.Length == 0)
            {
                await DisplayAlert("Upozorenje", "Vrijednosti naziva i poštanskog broja moraju biti unešeni!", "OK");
            }
            else
            {
                var postoji = database.Cities.Exists(a => a.Name.ToUpper() == Person.Name.ToUpper());
                if (postoji)
                {
                    await DisplayAlert("Upozorenje", "Grad sa istim imenom i poštanskim brojem već postoji!", "OK");
                }
                else
                {
                    // spremimo Person ako je novi
                    if (Person.Id == 0)
                    {
                        database.Persons.Insert(Person);
                    }
                    // ili ažuriramo ako je postojeci
                    else
                    {
                        database.Persons.Update(Person);
                    }

                    // vratimo se na popis osoba
                    await Navigation.PopAsync();
                }
            }
        }

        public ICommand DeleteCommand { get; }

        private async void Delete()
        {
            // pitati korisnika da li je siguran da zeli obrisati osobu

            var result = await DisplayAlert("Brisanje",
                                            "Jeste li ste sigurni da želite obrisati grad?",
                                            "Da",
                                            "Ne");

            if (result)
            {
                // ako je postojeca osoba obrisati ga iz baze
                if (Person.Id != 0)
                {
                    database.Cities.Delete((a) => a.Id == Person.Id);
                }

                // vratimo se na popis osoba
                await Navigation.PopAsync();
            }
        }

        private Person _person;

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
            }
        }

        private List<string> _genderList;

        public List<string> GenderList
        {
            get { return _genderList; }
            set
            {
                _genderList = value;
                OnPropertyChanged(nameof(GenderList));
            }
        }
    }
}
