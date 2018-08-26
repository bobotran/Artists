using System;
using System.Collections.Generic;
using System.Text;

namespace Artists.DTOs
{
    public class EventForCreationDto
    {
        public string DressCode { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Models.Address Address { get; set; }
    }
}
