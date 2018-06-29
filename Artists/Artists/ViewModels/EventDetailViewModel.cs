using System;

using Artists.Models;

namespace Artists.ViewModels
{
    public class EventDetailViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        private Place place;
        public EventDetailViewModel(Event ev = null)
        {
            //Title = ev?.Nickname;
            Event = ev;
            place = new Place { Name = Event.Address.AddressLine, Vicinity = Event.Address.City };
        }

        public void openMap()
        {
            Map.LaunchMapApp(place);
        }
    }
}
