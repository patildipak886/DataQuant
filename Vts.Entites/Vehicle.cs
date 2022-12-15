using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Vts.Entites
{
    public class Vehicle
    {
        public int VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ManufacturingYear { get; set; }
        public int LoadcarryingCapacity { get; set; }
        public string MakeOfVehicle { get; set; }
        public string ModelNumber { get; set; }
        public string BodyType { get; set; }
        public string OrganizationName { get; set; }
        public int DeviceId { get; set; }

        public int UserId { get; set; }


    }
}
