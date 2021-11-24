using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    class Employee
    {
        public int empID { get; set; }
        public string empName { get; set; }
        public string empNum { get; set; }
        public string empContact { get; set; }
        public string empPassword { get; set; }

        public Employee(int EmpID, string EmpName, string EmpNum, string EmpContact, string EmpPassword)
        {
            this.empID = EmpID;
            this.empName = EmpName;
            this.empNum = EmpNum;
            this.empContact = EmpContact;
            this.empPassword = EmpPassword;
        }

        public void UpdateEmployee(Employee E)
        {
            this.empID = E.empID;
            this.empName = E.empName;
            this.empNum = E.empNum;
            this.empContact = E.empContact;
            this.empPassword = E.empPassword;
        }
    }
}
