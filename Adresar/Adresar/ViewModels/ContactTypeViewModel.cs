using Adresar.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class ContactTypeViewModel : BaseViewModel
    {
        public ContactTypeViewModel()
        {
            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);
        }

        public ICommand SaveCommand { get; }

        private void Save()
        {

        }

        public ICommand DeleteCommand { get; }

        private void Delete()
        {

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
