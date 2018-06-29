using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Artists.Models
{
    public struct Address
    {
        public string AddressLine { get; }

        public string Building { get; }

        public string City { get; }

        public int FloorLevel { get; }

        public Address(string addressLine, string city, string building = "", int floorLevel = 0)
        {
            AddressLine = addressLine;
            City = city;
            Building = building;
            FloorLevel = floorLevel;
        }
    }

}
