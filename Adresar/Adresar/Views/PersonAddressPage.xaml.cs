using Adresar.Data;
using Adresar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonAddressPage : ContentPage
    {
        public PersonAddressPage(PersonAddress personAddress = null)
        {
            InitializeComponent();
            BindingContext = new PersonAddressViewModel(personAddress);
        }
    }
}