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

            var mainGrid = new Grid();
            mainGrid.Padding = new Thickness(10, 20);
            mainGrid.RowDefinitions = new RowDefinitionCollection();
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = 20 });
            Content = new Grid();
		}
	}
}