using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Vts.Entites
{
    public class Tracking
    {
        public int DeviceId { get; set; }
        public string Ignition { get; set; }
        public string PowerCut { get; set; }
        public string BoxOpen { get; set; }
        public int Odometer { get; set; }
        public int Speed { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string Location { get; set; }
        public int Altitude { get; set; }
        public string Direction { get; set; }

        public DateTime DeviceTime { get; set; }
    }
}
