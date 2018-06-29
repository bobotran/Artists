using System;
using System.Collections.Generic;
using System.Text;

namespace Artists.Models
{
    public class Place
    {
        public string Name { get; set; }
        public string Vicinity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Uri Icon { get; set; }
    }
}
