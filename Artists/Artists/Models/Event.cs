using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Artists.Models
{
    public class Event
    {
        private static IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

        public int Id { get; set; }
        public string DressCode { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Address Address { get; set; }

        public List<Performance> Performances { get; set; }

        //public Event()
        //{
        //    var today = DateTime.Today;
        //    StartTime = today.Add(new TimeSpan(9, 0, 0));
        //    EndTime = today.Add(new TimeSpan(11, 0, 0));
        //}
        public Event()
        {
            var today = DateTime.Today;
            StartTime = today.Add(new TimeSpan(9, 0, 0));
            EndTime = today.Add(new TimeSpan(11, 0, 0));
            Address = new Address();
            Performances = new List<Performance>();
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
        //Generates patch document by comparing two Events
        public static JsonPatchDocument<Event> GetJsonPatchDocument(Event pre_Patch, Event post_Patch)
        {
            JsonPatchDocument<Event> patchDoc = new JsonPatchDocument<Event>();
            if (post_Patch.DressCode != pre_Patch.DressCode)
            {
                patchDoc.Replace(e => e.DressCode, post_Patch.DressCode);
            }
            if (post_Patch.Nickname != pre_Patch.Nickname)
            {
                patchDoc.Replace(e => e.Nickname, post_Patch.Nickname);
            }
            if (post_Patch.Description != pre_Patch.Description)
            {
                patchDoc.Replace(e => e.Description, post_Patch.Description);
            }
            if (post_Patch.StartTime != pre_Patch.StartTime)
            {
                patchDoc.Replace(e => e.StartTime, post_Patch.StartTime);
            }
            if (post_Patch.EndTime != pre_Patch.EndTime)
            {
                patchDoc.Replace(e => e.EndTime, post_Patch.EndTime);
            }
            Address.UpdateJsonPatchDocument(patchDoc, pre_Patch.Address, post_Patch.Address);
            return patchDoc;
        }
    }
}