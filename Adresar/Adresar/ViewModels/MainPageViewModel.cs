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
        }

        public ICommand CityListPage { get; private set; }

        private async void GoToCityListPage()
        {
            await Navigation.PushAsync(new CityListPage());
        }
    }
}
