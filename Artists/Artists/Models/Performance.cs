using System;
using System.Collections.Generic;
using System.Text;

namespace Artists.Models
{
    public class Performance
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Host { get; set; }
        public List<Part> Parts { get; set; }
        public string Composer { get; set; }
        public Double Minutes { get; set; }
        public string Description { get; set; }
        
    }
}
