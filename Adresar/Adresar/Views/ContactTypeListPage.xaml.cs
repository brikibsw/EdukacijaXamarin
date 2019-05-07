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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as ContactTypeListViewModel;
            if(vm != null)
            {
                vm.LoadContactTypes();
            }
        }
    }
}