﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Artists.Models;
using Artists.Views;
using Artists.ViewModels;

namespace Artists.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventsPage : ContentPage
	{
        EventsViewModel viewModel;

        public EventsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EventsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Event;
            if (item == null)
                return;

            await Navigation.PushAsync(new EventDetailPage(new EventDetailViewModel(item)));

            // Manually deselect item.
            EventsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewEventPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                await viewModel.DeleteEventAsync((Event)mi.CommandParameter);
            }
        }
    }
}