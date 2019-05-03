using Adresar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactTypeListPage : ContentPage
    {
        public ContactTypeListPage()
        {
            InitializeComponent();
            BindingContext = new ContactTypeListViewModel();
        }
    }
}