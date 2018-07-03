using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Artists.Models;

namespace Artists.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            if (!Login.IsLoggedIn)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
	}
}