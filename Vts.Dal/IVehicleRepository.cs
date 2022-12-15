using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vts.Entites;

namespace Vts.Dal
{
    public interface IVehicleRepository
    {
        DataTable GetVehicles();

        Vehicle GetVehicles(int VehicleNumber);

        int InsertVehicle(Vehicle vehicle);
        int UpdateVehicle(Vehicle vehicle);
        int DeleteVehicle(int VehicleNumber);
    }
}
