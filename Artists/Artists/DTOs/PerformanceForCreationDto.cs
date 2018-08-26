using Artists.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artists.DTOs
{
    public class PerformanceForCreationDto
    {
        public string Title { get; set; }
        public string Host { get; set; }
        public List<Part> Parts { get; set; }
        public string Composer { get; set; }
        public Double Minutes { get; set; }
        public string Description { get; set; }
    }
}
