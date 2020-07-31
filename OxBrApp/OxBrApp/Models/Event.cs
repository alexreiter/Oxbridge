using System;
using System.Collections.Generic;
using System.Text;

namespace OxBrApp.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string RaceTitle { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

        public string StartTime { get; set; }
    }
}
