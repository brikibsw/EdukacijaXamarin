using Adresar.Data;
using Adresar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CityPage : ContentPage
	{
		public CityPage (City city = null)
		{
			InitializeComponent ();
            var vm = new CityPageViewModel();
            if( city != null )
            {
                vm.City = city;
            }

            BindingContext = vm;
        }
	}
}