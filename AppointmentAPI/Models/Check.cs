using System;
using System.Collections.Generic;

#nullable disable

namespace AppointmentAPI.Models
{
    public partial class Check
    {
        public int Id { get; set; }
        public string AppVersion { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public double Latitute { get; set; }
        public double Longitute { get; set; }
        public string DeviceAgent { get; set; }
        public string Platform { get; set; }
        public string PlatformVersion { get; set; }
    }
}
