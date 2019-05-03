using Adresar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactTypePage : ContentPage
    {
        public ContactTypePage()
        {
            InitializeComponent();
            BindingContext = new ContactTypeViewModel();
        }
    }
}