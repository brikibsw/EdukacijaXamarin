using Adresar.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonListPage : ContentPage
    {
        public PersonListPage()
        {
            InitializeComponent();
            BindingContext = new PersonListViewModel();
        }
    }
}