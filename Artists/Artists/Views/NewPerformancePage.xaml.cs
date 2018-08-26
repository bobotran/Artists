using Artists.Models;
using Artists.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Artists.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPerformancePage : ContentPage
    {
        public NewPerformanceViewModel ViewModel { get; set; }

        private Part EditedPart;
        public NewPerformancePage()
        {
            InitializeComponent();

            ViewModel = new NewPerformanceViewModel();

            BindingContext = ViewModel;

            ViewModel.Parts.CollectionChanged += updateListView;
        }
        

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public void AddItem_Clicked(object sender, EventArgs e)
        {
            ViewModel.addPartFromEntries();

            ViewModel.resetNewPartEntries();
        }
        public void SaveEdit_Clicked(object sender, EventArgs e)
        {
            EditedPart.setNameColors(Part.DefaultPartNameColor, User.DefaultPerformerNameColor);
            ViewModel.updatePart(EditedPart);
            ViewModel.resetNewPartEntries();

            toggleButton(PartsButton);
        }

        private void ListLayout_SizeChanged(object sender, EventArgs e)
        {
            PartsListView.updateCellSize(sender);
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            ViewModel.PartsButtonIsVisible = true;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if( entriesEmpty(PartNameEntry.Text, PerformerNameEntry.Text ) )
            {
                ViewModel.PartsButtonIsVisible = false;
            }
        }

        private void EditItem_Clicked(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                Part part = (Part)mi.CommandParameter;
                EditedPart = part;
                part.setNameColors(NewPerformanceViewModel.HighlightedColor);

                ViewModel.setNewPartEntriesTo(part);

                toggleButton(PartsButton);
            }
        }
        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if(mi != null)
            {
                ViewModel.Parts.Remove((Part)mi.CommandParameter);
            }
            
        }

        private void toggleButton(Button button)
        {
            if(button.Text == "Add")
            {
                button.Text = "Save";
                button.Clicked -= AddItem_Clicked;
                button.Clicked += SaveEdit_Clicked;
            }
            else
            {
                button.Text = "Add";
                button.Clicked -= SaveEdit_Clicked;
                button.Clicked += AddItem_Clicked;
            }
        }

        private Boolean entriesEmpty(string a, string b)
        {
            return (a == null && b == null) || (a.Length == 0 && b == null) || 
                (a == null && b.Length == 0) || (a.Length == 0 && b.Length == 0);
        }

        private void updateListView(object sender, EventArgs e)
        {
            PartsListView.updateListViewSize();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {

        }
    }
}
