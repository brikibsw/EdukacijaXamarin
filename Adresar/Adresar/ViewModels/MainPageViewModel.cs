using Adresar.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            CityListPage = new Command(GoToCityListPage);
            ContactTypeListPage = new Command(GoToContactType);
            PersonListPage = new Command(GoToPersonListPage);
        }

        public ICommand CityListPage { get; }

        private async void GoToCityListPage()
        {
            await Navigation.PushAsync(new CityListPage());
        }

        public ICommand ContactTypeListPage { get; }

        private async void GoToContactType()
        {
            await Navigation.PushAsync(new ContactTypeListPage());
        }

        public ICommand PersonListPage { get; }

        public async void GoToPersonListPage()
        {
            await Navigation.PushAsync(new PersonListPage());
        }
    }
}
