using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Artists.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }

        public string Building { get; set; }

        public string City { get; set; }

        public int FloorLevel { get; set; }
        
        //Helper method called by Event.GetJsonPatchDocument(). Updates the JsonPatchDoc to include changes in Event.Address
        public static void UpdateJsonPatchDocument(JsonPatchDocument<Event> eventPatchDoc, Address pre_Patch, Address post_Patch)
        {
            if (post_Patch.AddressLine != pre_Patch.AddressLine)
            {
                eventPatchDoc.Replace(e => e.Address.AddressLine, post_Patch.AddressLine);
            }
            if (post_Patch.Building != pre_Patch.Building)
            {
                eventPatchDoc.Replace(e => e.Address.Building, post_Patch.Building);
            }
            if (post_Patch.City != pre_Patch.City)
            {
                eventPatchDoc.Replace(e => e.Address.City, post_Patch.City);
            }
            if (post_Patch.FloorLevel != pre_Patch.FloorLevel)
            {
                eventPatchDoc.Replace(e => e.Address.FloorLevel, post_Patch.FloorLevel);
            }
        }
    }

}
