using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Artists.Models;
using Artists.Views;

namespace Artists.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EventsViewModel()
        {
            Title = "Upcoming Events";
            Items = new ObservableCollection<Event>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewEventPage, Event>(this, "AddEvent", async (obj, item) =>
            {
                var _item = item as Event;
                Items.Add(_item);
                await EventManager.AddItemAsync(_item);
            });

            MessagingCenter.Subscribe<NewEventPage, Event>(this, "EditEvent", async (obj, item) =>
            {
                var _event = item as Event;

                await EventManager.UpdateItemAsync(_event);
            });
        }

        public async Task DeleteEventAsync(Event ev)
        {
            Items.Remove(ev);
            await EventManager.DeleteItemAsync(ev.Id);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await EventManager.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}