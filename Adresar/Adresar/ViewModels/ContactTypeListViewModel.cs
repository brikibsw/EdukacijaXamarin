using Adresar.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class ContactTypeListViewModel : BaseViewModel
    {
        public ContactTypeListViewModel()
        {
            NewContactTypeCommand = new Command(NewCommandType);
        }

        public ICommand NewContactTypeCommand { get; }

        private void NewCommandType()
        {
            Navigation.PushAsync(new ContactTypePage());
        }
    }
}
