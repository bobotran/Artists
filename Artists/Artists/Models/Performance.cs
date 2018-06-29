using System;
using System.Collections.Generic;
using System.Text;

namespace Artists.Models
{
    public class Performance
    {
        public string Title { get; set; }
        public string Host { get; set; }
        public List<Part> Parts { get; set; }
        public string Composer { get; set; }
        public Double Minutes { get; set; }
        public string Description { get; set; }

        //later to be a list of User/Perfomer
        //public List<Performer> Performers { get; set; }

        
    }
}
