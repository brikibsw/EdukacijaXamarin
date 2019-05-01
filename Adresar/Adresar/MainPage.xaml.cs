using Adresar.ViewModels;
using Xamarin.Forms;

namespace Adresar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
