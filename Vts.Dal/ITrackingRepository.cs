using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vts.Entites;

namespace Vts.Dal
{
    public interface ITrackingRepository
    {

        DataTable GetTrackings();

        Tracking GetTracking(int DeviceId);

        int InserTracking(Tracking Tracking);
        int UpdateTracking(Tracking Tracking);
        int DeleteTracking(int DeviceId);
    }
}
