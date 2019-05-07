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
    public class ContactTypeListViewModel : BaseViewModel
    {
        private readonly AdresarDatabase database;

        public ContactTypeListViewModel()
        {
            database = new AdresarDatabase();

            NewContactTypeCommand = new Command(NewCommandType);
        }

        public ICommand NewContactTypeCommand { get; }

        private void NewCommandType()
        {
            Navigation.PushAsync(new ContactTypePage());
        }

        private List<ContactType> originalniTipovi { get; set; }

        public void LoadContactTypes()
        {
            originalniTipovi = database.ContactTypes.FindAll().ToList();
            ContactTypes = new List<ContactType>(originalniTipovi);
        }

        private List<ContactType> _contactTypes;

        public List<ContactType> ContactTypes
        {
            get { return _contactTypes; }
            set
            {
                _contactTypes = value;
                OnPropertyChanged(nameof(ContactTypes));
            }
        }

        private string _search;

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                SearchContactTypes();
            }
        }

        private void SearchContactTypes()
        {
            if (Search != null && Search.Length > 0)
            {
                var rezultat = originalniTipovi.Where(a => a.Name.ToUpper().StartsWith(Search.ToUpper()));
                ContactTypes = new List<ContactType>(rezultat);
            }
            else
            {
                ContactTypes = new List<ContactType>(originalniTipovi);
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
                NavigateToContactTypePage();
            }
        }

        public void NavigateToContactTypePage()
        {
            if( ContactType != null )
            {
                Navigation.PushAsync(new ContactTypePage(ContactType));
            }
        }
            
    }
}
