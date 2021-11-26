using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class EmpList
    {
        private List<Employee> E_List = new List<Employee>();
        private static Connection c = new Connection();
        SqlConnection conn = c.conn;

        //Add an Employee to the DB
        public void AddToDB(Employee e)
        {
            SqlCommand command = new
                            SqlCommand("INSERT INTO tblEmployees (empNum, empName, empContact, empRole) " +
                                       "VALUES(@empNum, @empName, @empContact, @empRole) ;", conn);
            command.Parameters.AddWithValue("@empNum", e.empNum);
            command.Parameters.AddWithValue("@empName", e.empName);
            command.Parameters.AddWithValue("@empContact", e.empContact);
            command.Parameters.AddWithValue("@empRole", e.empRole);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        public string EmpNumGen(string name)
        {
            string answer = "";
            answer += name.Substring(0, 2).ToUpper();

            Random r = new Random();
            int num = r.Next(1000, 10000);

            answer += num.ToString();

            if (this.List().Where(x => x.empNum == answer).FirstOrDefault() != null)
            {
                return EmpNumGen(name);
            }

            return answer;
        }

        //Update Employee Based on Employee Number
        public void UpdateEmployee(Employee e)
        {
            SqlCommand command = new
                            SqlCommand("UPDATE tblEmployees " +
                                       $"SET empName = '{e.empName}', empContact = '{e.empContact}', empRole = '{e.empRole}' " +
                                       $"WHERE empNum = '{e.empNum}';", conn);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        //Delete Employee based on Employee Number
        public void DeleteEmployee(Employee e)
        {
            SqlCommand command = new SqlCommand(
                "DELETE FROM tblEmployees " +
                $"WHERE empNum='{e.empNum}';", conn);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        //Get a list of all orders
        public List<Employee> List()
        {
            conn.Open();

            String sql =
                "SELECT * " +
                "FROM tblEmployees; ";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader r = command.ExecuteReader();

            E_List.Clear();

            while (r.Read())
            {
                Employee e = new Employee();

                e.empNum = r.GetString(0);
                e.empName = r.GetString(1);
                e.empContact = r.GetString(2);
                e.empRole = r.GetString(3);

                E_List.Add(e);
            }

            r.Close();
            command.Dispose();
            conn.Close();

            return E_List;
        }

        //Get a list of orders for a specific customer id
        public List<Employee> List(string EmpNum)
        {
            conn.Open();

            String sql =
                "SELECT * " +
                "FROM tblEmployees " +
                $"WHERE empNum = '{EmpNum}'; ";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader r = command.ExecuteReader();

            E_List.Clear();

            while (r.Read())
            {
                Employee e = new Employee();

                e.empNum = r.GetString(0);
                e.empName = r.GetString(1);
                e.empContact = r.GetString(2);
                e.empRole = r.GetString(3);

                E_List.Add(e);
            }

            r.Close();
            command.Dispose();
            conn.Close();

            return E_List;
        }
    }
}
