using System;

using Artists.Models;

namespace Artists.ViewModels
{
    public class EventDetailViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public EventDetailViewModel(Event ev = null)
        {
            //Title = ev?.Nickname;
            Event = ev;
        }
    }
}
