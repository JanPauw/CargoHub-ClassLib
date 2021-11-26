using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class UserList
    {
        private List<User> U_List = new List<User>();
        private static Connection c = new Connection();
        SqlConnection conn = c.conn;

        public UserList()
        {

        }

        //Delete Employee based on Employee Number
        public void DeleteUser(User u)
        {
            SqlCommand command = new SqlCommand(
                "DELETE FROM tblUsers " +
                $"WHERE empNum='{u.EmpNum}';", conn);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        //Get a list of all orders
        public List<User> List()
        {
            conn.Open();

            String sql =
                "SELECT * " +
                "FROM tblUsers; ";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader r = command.ExecuteReader();

            U_List.Clear();

            while (r.Read())
            {
                User u = new User();

                u.Username = r.GetString(0);
                u.EmpNum = r.GetString(2);

                U_List.Add(u);
            }

            r.Close();
            command.Dispose();
            conn.Close();

            return U_List;
        }
    }
}
