using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Artists.Models;
using Artists.ViewModels;

namespace Artists.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEventPage : ContentPage
    {
        public NewEventViewModel viewModel;


        //Called when a new event is being created
        public NewEventPage()
        {
            InitializeComponent();
            Title = "New Event";
            Event ev = new Event();

            viewModel = new NewEventViewModel(ev);
            BindingContext = viewModel;

            NewEventPageButton.Clicked += Save_Clicked;
        }

        //Called when an event is being edited
        public NewEventPage(Event original)
        {
            InitializeComponent();
            Title = "Edit Event";

            viewModel = new NewEventViewModel(original);
            BindingContext = viewModel;

            NewEventPageButton.Clicked += Save_Edit_Clicked;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            viewModel.processEntries();

            MessagingCenter.Send(this, "AddEvent", viewModel.Event);
            await Navigation.PopModalAsync();
        }

        async void Save_Edit_Clicked(object sender, EventArgs e)
        {
            viewModel.processEntries();

            MessagingCenter.Send(this, "EditEvent", viewModel.Event);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}