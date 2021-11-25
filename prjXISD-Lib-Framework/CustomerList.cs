using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class CustomerList
    {
        private List<Customer> C_List = new List<Customer>();
        private static Connection c = new Connection();
        SqlConnection conn = c.conn;

        //Add a Customer to the DB
        public void AddToDB(Customer C)
        {
            SqlCommand command = new
                            SqlCommand("INSERT INTO tblCustomers (custName, custAddress, custProvince, custEmail, custNum) " +
                                       "VALUES(@custName, @custAddress, @custProvince, @custEmail, @custNum) ;", conn);
            command.Parameters.AddWithValue("@custName", C.custName);
            command.Parameters.AddWithValue("@custAddress", C.custAddress);
            command.Parameters.AddWithValue("@custProvince", C.custProvince);
            command.Parameters.AddWithValue("@custEmail", C.custEmail);
            command.Parameters.AddWithValue("@custNum", C.custNum);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        public void UpdateCustomer(Customer C)
        {
            SqlCommand command = new SqlCommand(
                $"UPDATE tblCustomers " +
                $"SET custName = @custName, custAddress = @custAddress, custProvince = @custProvince, custEmail = @custEmail, custNum = @custNum " +
                $"WHERE custID = {C.custID}", conn);

            command.Parameters.AddWithValue("@custName", C.custName);
            command.Parameters.AddWithValue("@custAddress", C.custAddress);
            command.Parameters.AddWithValue("@custProvince", C.custProvince);
            command.Parameters.AddWithValue("@custEmail", C.custEmail);
            command.Parameters.AddWithValue("@custNum", C.custNum);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        //Delete Module based on Module Code
        public void DeleteCustomer(Customer C)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(
                "DELETE " +
                "FROM tblCustomers " +
                $"WHERE custID={C.custID}", conn))
            {
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        //Get latest List of Customers
        public List<Customer> List()
        {
            conn.Open();

            String sql =
                "SELECT * " +
                "FROM tblCustomers; ";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader r = command.ExecuteReader();

            C_List.Clear();

            while (r.Read())
            {
                Customer C = new Customer();

                C.custID = r.GetInt32(0);
                C.custName = r.GetString(1);
                C.custAddress = r.GetString(2);
                C.custProvince = r.GetString(3);
                C.custEmail = r.GetString(4);
                C.custNum = r.GetString(5);

                C_List.Add(C);
            }

            r.Close();
            command.Dispose();
            conn.Close();

            return C_List;
        }
    }
}
