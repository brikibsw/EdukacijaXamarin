using Adresar.Data;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class ContactTypeViewModel : BaseViewModel
    {
        private readonly AdresarDatabase database;
        public ContactTypeViewModel(ContactType contactType)
        {
            database = new AdresarDatabase();

            if(contactType == null)
            {
                ContactType = new ContactType();
            }
            else
            {
                ContactType = contactType;
            }

            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);
        }

        public ICommand SaveCommand { get; }

        private async void Save()
        {
            if( ContactType.Name == null || ContactType.Name.Length == 0 )
            {
                await DisplayAlert("Upozorenje", "Vrijednost naziva mora biti unešena!!!", "OK");
            }
            else
            {
                var postoji = database.ContactTypes.Exists(a => a.Name.ToUpper() == ContactType.Name.ToUpper());
                if( postoji == true  )
                {
                    await DisplayAlert("Upozorenje", "Tip kontakta sa istim nazivom već postoji!!", "OK");
                }
                else
                {
                    if( ContactType.Id == 0 )
                    {
                        database.ContactTypes.Insert(ContactType);
                    }
                    else
                    {
                        database.ContactTypes.Update(ContactType);
                    }

                    await Navigation.PopAsync();
                }
            }
        }

        public ICommand DeleteCommand { get; }

        private async void Delete()
        {
            var result = await DisplayAlert("Brisanje",
                                            "Jeste li sigurni da želite obrisati tip kontakta?",
                                            "Da",
                                            "Ne");
            if(result)
            {
                if(ContactType.Id != 0)
                {
                    database.ContactTypes.Delete(a => a.Id == ContactType.Id);
                }

                await Navigation.PopAsync();
            }
        }

        private ContactType _contactType;
        public ContactType ContactType
        {
            get { return _contactType; }
            set
            {
                _contactType = value;
                OnPropertyChanged(nameof(ContactType));
            }
        }
    }
}
