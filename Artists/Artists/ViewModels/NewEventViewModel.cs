using System;
using System.Collections.Generic;
using System.Text;

using Artists.Models;

namespace Artists.ViewModels
{
    public class NewEventViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public string NicknameEntry { get; set; }
        public string DressCodePicker { get; set; }
        public string DescriptionEditor { get; set; }
        public string AddressLineEntry { get; set; }
        public string CityEntry { get; set; }
        public string BuildingEntry { get; set; }
        public int FloorLevelEntry { get; set; }
        public TimeSpan StartSpan { get; set; }
        public TimeSpan EndSpan { get;  set; }

        public DateTime Date { get; set; }

        public NewEventViewModel(Event ev)
        {
            Event = ev;

            NicknameEntry = Event.Nickname;
            DressCodePicker = Event.DressCode;
            DescriptionEditor = Event.Description;
            AddressLineEntry = Event.Address.AddressLine;
            CityEntry = Event.Address.City;
            BuildingEntry = Event.Address.Building;
            FloorLevelEntry = Event.Address.FloorLevel;
            StartSpan = Event.StartTime.TimeOfDay;
            EndSpan = Event.EndTime.TimeOfDay;
            Date = Event.StartTime.Date;
        }

        public void processEntries()
        {
            Event.Nickname = NicknameEntry;
            Event.DressCode = DressCodePicker;
            Event.Description = DescriptionEditor;

            Event.StartTime = Date.Add(StartSpan);
            Event.EndTime = Date.Add(EndSpan);

            Event.Address = new Address(AddressLineEntry, CityEntry, BuildingEntry, FloorLevelEntry);

            //Event.StartTime = Convert.ToDateTime(StartSpan.ToString());
            //Event.EndTime = Convert.ToDateTime(EndSpan.ToString());
        }
    }
}
