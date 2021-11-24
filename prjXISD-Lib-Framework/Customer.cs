using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class Customer
    {
        public int custID { get; set; }
        public string custName { get; set; }
        public string custAddress { get; set; }
        public string custProvince { get; set; }
        public string custEmail { get; set; }
        public string custNum { get; set; }

        public Customer()
        {

        }

        public Customer(int CustID, string CustName, string CustAddress, string CustProvince, string CustEmail, string CustNum)
        {
            this.custName = CustName;
            this.custAddress = CustAddress;
            this.custProvince = CustProvince;
            this.custEmail = CustEmail;
            this.custNum = CustNum;
        }

        public void UpdateCustomer(Customer C)
        {
            this.custName = C.custName;
            this.custAddress = C.custAddress;
            this.custProvince = C.custProvince;
            this.custEmail = C.custEmail;
            this.custNum = C.custNum;
        }
    }
}
