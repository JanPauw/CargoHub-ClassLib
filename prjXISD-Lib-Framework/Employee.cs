using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class Employee
    {
        public int empID { get; set; }
        public string empName { get; set; }
        public string empNum { get; set; }
        public string empContact { get; set; }
        public string empRole { get; set; }

        public Employee(int EmpID, string EmpName, string EmpNum, string EmpContact, string EmpRole)
        {
            this.empID = EmpID;
            this.empName = EmpName;
            this.empNum = EmpNum;
            this.empContact = EmpContact;
            this.empRole = EmpRole;
        }

        public Employee()
        {

        }

        public void UpdateEmployee(Employee E)
        {
            this.empID = E.empID;
            this.empName = E.empName;
            this.empNum = E.empNum;
            this.empContact = E.empContact;
        }
    }
}
