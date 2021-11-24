using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class Order
    {
        public string ordNum { get; set; }
        public string ordID { get; set; }
        public string ordCargo { get; set; }
        public int ordQuantity { get; set; }
        public string toDepot { get; set; }
        public string fromDepot { get; set; }
        public string custID { get; set; }
        public DateTime? ordDate { get; set; }
        public string ordStatus { get; set; }

        public Order()
        {

        }

        public Order(string OrdNum, string OrdID, string OrdCargo, int OrdQuantity, string ToDepot, string FromDepot, string custID, DateTime? OrdDate, string OrdStatus)
        {
            this.ordNum = OrdNum;
            this.ordID = OrdID;
            this.ordCargo = OrdCargo;
            this.ordQuantity = OrdQuantity;
            this.toDepot = ToDepot;
            this.fromDepot = FromDepot;
            this.custID = custID;
            this.ordStatus = OrdStatus;
        }

        public void UpdateOrder(Order O)
        {
            this.ordNum = O.ordNum;
            this.ordID = O.ordID;
            this.ordCargo = O.ordCargo;
            this.ordQuantity = O.ordQuantity;
            this.toDepot = O.toDepot;
            this.fromDepot = O.fromDepot;
            this.custID = O.custID;
            this.ordDate = O.ordDate;
            this.ordStatus = O.ordStatus;
        }
    }
}
