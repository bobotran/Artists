using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Artists.Models;
using Artists.ViewModels;

namespace Artists.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetailPage : ContentPage
	{
        EventDetailViewModel viewModel;

        public EventDetailPage(EventDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            //BindingContext = viewModel.Event;
        }

        public EventDetailPage()
        {
            InitializeComponent();

            var item = new Event
            {
                Nickname = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new EventDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            var page = new NewEventPage(viewModel.Event);
            await Navigation.PushModalAsync(new NavigationPage(page));
        }

        async void NewPerformance_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPerformancePage()));
        }

        private void Address_Clicked(object sender, EventArgs e)
        {
            viewModel.openMap();
        }
    }
}