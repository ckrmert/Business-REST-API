using System;
using System.Collections.Generic;

#nullable disable

namespace AppointmentAPI.Models
{
    public partial class Banner
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int? Sorting { get; set; }
    }
}
