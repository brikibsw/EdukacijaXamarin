using Adresar.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CityListPage : ContentPage
	{
		public CityListPage ()
		{
			InitializeComponent ();

            BindingContext = new CityListPageViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as CityListPageViewModel;
            if( vm != null )
            {
                Task.Factory.StartNew(()=> vm.LoadCities());
            }
        }
    }
}