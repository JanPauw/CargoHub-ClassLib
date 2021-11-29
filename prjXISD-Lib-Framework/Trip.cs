using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    class Trip
    {
        public string ordNum { get; set; }
        public string tripPickup { get; set; }
        public string tripDest { get; set; }
        public string tripDist { get; set; }

        public Trip()
        {

        }

        public string Distance(double[] from, double[] to)
        {
            var sCoord = new GeoCoordinate(from[0], from[1]);
            var eCoord = new GeoCoordinate(to[0], to[1]);

            return (sCoord.GetDistanceTo(eCoord) / 1000).ToString();
        }
    }
}
