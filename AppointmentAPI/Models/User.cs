using System;
using System.Collections.Generic;

#nullable disable

namespace AppointmentAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
