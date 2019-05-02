using Adresar.ViewModels;
using System;
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
    }
}