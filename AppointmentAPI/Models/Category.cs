using System;
using System.Collections.Generic;

#nullable disable

namespace AppointmentAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Personels = new HashSet<Personel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Sorting { get; set; }
        public string IconName { get; set; }
        public string IconColour { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
