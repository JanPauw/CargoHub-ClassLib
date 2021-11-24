using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    class Depot
    {
        public int depID { get; set; }
        public string depAddress { get; set; }
        public string depProvince { get; set; }
        public string depNum { get; set; }

        public Depot(int DepID, string DepAddress, string DepProvince, string DepNum)
        {
            this.depID = DepID;
            this.depAddress = DepAddress;
            this.depProvince = DepProvince;
            this.depNum = DepNum;
        }

        public void UpdateDepot(Depot D)
        {
            this.depID = D.depID;
            this.depAddress = D.depAddress;
            this.depProvince = D.depProvince;
            this.depNum = D.depNum;
        }
    }
}
