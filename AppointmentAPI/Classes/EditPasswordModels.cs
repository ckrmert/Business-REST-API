using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentAPI.Classes
{
    public class EditPasswordModels
    {
        public int userId { get; set; }
        public string newPassword { get; set; }
    }
}
