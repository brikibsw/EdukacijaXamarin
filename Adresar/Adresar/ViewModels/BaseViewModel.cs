using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        public INavigation Navigation { get => Application.Current.MainPage.Navigation; }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose()
        {
            
        }
    }
}
