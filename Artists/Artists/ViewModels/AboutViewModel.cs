using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Artists.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Club Website";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://tshs-capousd-ca.schoolloop.com/performingartists")));
        }

        public ICommand OpenWebCommand { get; }
    }
}