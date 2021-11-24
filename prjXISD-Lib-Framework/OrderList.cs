using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class OrderList
    {
        private List<Order> O_List = new List<Order>();
        private static Connection c = new Connection();
        SqlConnection conn = c.conn;

        public OrderList()
        {

        }

        public string OrderNumGen(string name)
        {
            string answer = "";
            answer += name.Substring(0, 2);

            Random r = new Random();
            int num = r.Next(10000000, 100000000);

            return answer;
        }

        //Add an Order to the DB
        public void AddToDB(Order o)
        {
            SqlCommand command = new
                            SqlCommand("INSERT INTO tblOrders (ordNum, ordID, ordCargo, ordQuantity, toDepot, fromDepot, custID, ordDate) " +
                                       "VALUES(@ordNum, @ordCargo, @ordQuantity, @toDepot, @fromDepot, @custID, @ordDate) ;", conn);
            command.Parameters.AddWithValue("@ordNum", o.ordNum);
            command.Parameters.AddWithValue("@ordCargo", o.ordCargo);
            command.Parameters.AddWithValue("@ordQuantity", o.ordQuantity);
            command.Parameters.AddWithValue("@toDepot", o.toDepot);
            command.Parameters.AddWithValue("@fromDepot", o.fromDepot);
            command.Parameters.AddWithValue("@custID", o.custID);
            command.Parameters.AddWithValue("@ordDate", o.ordDate);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        public List<Order> List()
        {
            conn.Open();

            String sql =
                "SELECT * " +
                "FROM tblOrders; ";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader r = command.ExecuteReader();

            O_List.Clear();

            while (r.Read())
            {
                Order o = new Order();

                o.ordNum = r.GetString(0);
                o.ordCargo = r.GetString(1);
                o.ordQuantity = r.GetInt32(2);
                o.toDepot = r.GetString(3);
                o.fromDepot = r.GetString(4);
                o.custID = r.GetString(5);
                o.ordDate = r.GetDateTime(6);
                o.ordStatus = r.GetString(7);

                O_List.Add(o);
            }

            r.Close();
            command.Dispose();
            conn.Close();

            return O_List;
        }
    }
}
