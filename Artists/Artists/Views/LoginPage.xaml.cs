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
	public partial class LoginPage : ContentPage
	{
        LoginViewModel viewModel;
		public LoginPage ()
		{
			InitializeComponent ();

            viewModel = new LoginViewModel();
		}

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            focusView(UsernameEntry);
            LoginButton.IsVisible = false;
        }

        private void focusView(View view)
        {
            view.IsVisible = true;
            view.Focus();
        }

        private void UsernameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            focusView(PasswordEntry);
        }

        private void PasswordEntry_Unfocused(object sender, FocusEventArgs e)
        {
            focusView(ArrowButton);
        }

        private async void ArrowButton_Clicked(object sender, EventArgs e)
        {
            Login.Log_In(UsernameEntry.Text, PasswordEntry.Text);
            await Navigation.PopModalAsync();
        }
    }
}