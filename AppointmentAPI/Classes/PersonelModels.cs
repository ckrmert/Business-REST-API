using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentAPI.Classes
{
    public class PersonelModels
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }
        public int Star { get; set; }
        public string Title { get; set; }
        public int AppoinmentCount { get; set; }
        public bool OnlineStatus { get; set; }
        public int CategoryId { get; set; }
        public int? Sorting { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }




    }
}
