using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentAPI.Classes
{
    public class ResultCheckApi
    {
       public bool appVersion { get; set; }
       public bool ipAddress { get; set; }
       public bool macAddress { get; set; }
       public bool platformVersion { get; set; }
       public String result { get; set; }

    }
}
