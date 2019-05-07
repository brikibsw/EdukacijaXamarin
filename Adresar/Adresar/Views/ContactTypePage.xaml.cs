using Adresar.Data;
using Adresar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactTypePage : ContentPage
    {
        public ContactTypePage(ContactType contactType = null)
        {
            InitializeComponent();
            BindingContext = new ContactTypeViewModel(contactType);
        }
    }
}