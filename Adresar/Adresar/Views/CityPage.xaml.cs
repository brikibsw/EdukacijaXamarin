using Adresar.Data;
using Adresar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adresar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CityPage : ContentPage
	{
		public CityPage(City grad = null)
		{
			InitializeComponent ();
            BindingContext = new CityPageViewModel(grad);
		}
	}
}