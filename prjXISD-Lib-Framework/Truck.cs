using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    class Truck
    {
        public int vehID { get; set; }
        public string vehRegNum { get; set; }
        public string vehType { get; set; }
        public string vehManufacturer { get; set; }
        public string vehEngineSize { get; set; }
        public string vehOdoReading { get; set; }
        public string vehNextService { get; set; }

        public Truck(int VehID, string VehRegNum, string VehType, string VehManufacturer, string VehEngineSize,
            string VehOdoReading, string VehNextSerice)
        {
            this.vehID = VehID;
            this.vehRegNum = VehRegNum;
            this.vehType = VehType;
            this.vehManufacturer = VehManufacturer;
            this.vehEngineSize = VehEngineSize;
            this.vehOdoReading = VehOdoReading;
            this.vehNextService = VehNextSerice;
        }

        public void UpdateTruck(Truck T)
        {
            this.vehID = T.vehID;
            this.vehRegNum = T.vehRegNum;
            this.vehType = T.vehType;
            this.vehManufacturer = T.vehManufacturer;
            this.vehEngineSize = T.vehEngineSize;
            this.vehOdoReading = T.vehOdoReading;
            this.vehNextService = T.vehNextService;
        }
    }
}
