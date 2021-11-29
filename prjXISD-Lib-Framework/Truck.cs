using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class Truck
    {
        public string vehRegNum { get; set; }
        public string vehType { get; set; }
        public string vehManufacturer { get; set; }
        public string vehEngineSize { get; set; }
        public string vehOdoReading { get; set; }
        public string vehNextService { get => this.NextService(); set => this.NextService(); }
        public string vehStatus { get; set; }
        public string empNum { get; set; }

        public string NextService()
        {
            double calculation = Convert.ToDouble(this.vehOdoReading) / 20000;
            double result = Math.Ceiling(calculation);
            int temp = Convert.ToInt32(result);
            return temp.ToString();
        }

        public Truck(string VehRegNum, string VehType, string VehManufacturer, string VehEngineSize,
            string VehOdoReading, string VehNextSerice, string VehStatus, string EmpNum)
        {
            this.vehRegNum = VehRegNum;
            this.vehType = VehType;
            this.vehManufacturer = VehManufacturer;
            this.vehEngineSize = VehEngineSize;
            this.vehOdoReading = VehOdoReading;
            this.vehNextService = VehNextSerice;
            this.vehStatus = VehStatus;
            this.empNum = EmpNum;
        }

        public Truck()
        {

        }

        public void UpdateTruck(Truck T)
        {
            this.vehRegNum = T.vehRegNum;
            this.vehType = T.vehType;
            this.vehManufacturer = T.vehManufacturer;
            this.vehEngineSize = T.vehEngineSize;
            this.vehOdoReading = T.vehOdoReading;
            this.vehNextService = T.vehNextService;
            this.vehStatus = T.vehStatus;
            this.empNum = T.empNum;
        }
    }
}
