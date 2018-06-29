using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Artists.Models
{
    public class Event : INotifyPropertyChanged
    {
        private static IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);



        private string dressCode;
        public string DressCode { get { return dressCode; } set { SetProperty(ref dressCode, value); } }


        
        public string Id { get; set; }



        private string nickname;
        public string Nickname { get { return nickname; } set { SetProperty(ref nickname, value); } }



        private string description;
        public string Description { get { return description; } set { SetProperty(ref description, value); } }



        private DateTime startTime;
        public DateTime StartTime { get { return startTime; } set { SetProperty(ref startTime, value); } }


        private DateTime endTime;
        public DateTime EndTime { get { return endTime; } set { SetProperty(ref endTime, value); } }


        private Address address;
        public Address Address { get { return address; } set { SetProperty(ref address, value); } }


        private List<Performance> performances;
        public List<Performance> Performances { get { return performances; } set { SetProperty(ref performances, value); } }

        public Event()
        {
            var today = DateTime.Today;
            StartTime = today.Add(new TimeSpan(9, 0, 0));
            EndTime = today.Add(new TimeSpan(11, 0, 0));
        }

        //Creates a new Event with the same properties as *mold*
        public Event(Event mold)
        {
            this.CopyPropertiesOf(mold);
        }

        public void CopyPropertiesOf(Event other)
        {
            this.DressCode = other.DressCode;
            this.Nickname = other.Nickname;
            this.Description = other.Description;
            this.StartTime = other.StartTime;
            this.EndTime = other.EndTime;
            this.Address = other.Address;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "", string[] propertyNames = null,
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}