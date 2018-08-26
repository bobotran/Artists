using Artists.Models;
using Artists.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Artists.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MePage : ContentPage
	{
        private MePageViewModel viewModel;
		public MePage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new MePageViewModel();
        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Users.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}