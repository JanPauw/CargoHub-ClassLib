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

        //Update Order based on existing Order's 10-digit Number
        public void UpdateOrder(Order O)
        {
            SqlCommand command = new SqlCommand(
                $"UPDATE tblOrders " +
                $"SET ordCargo = @ordCargo, ordQuantity = @ordQuantity, toDepot = @toDepot, fromDepot = @fromDepot, ordStatus = @ordStatus " +
                $"WHERE ordNum = '{O.ordNum}'", conn);

            command.Parameters.AddWithValue("@ordCargo", O.ordCargo);
            command.Parameters.AddWithValue("@ordQuantity", O.ordQuantity);
            command.Parameters.AddWithValue("@toDepot", O.toDepot);
            command.Parameters.AddWithValue("@fromDepot", O.fromDepot);
            command.Parameters.AddWithValue("@ordStatus", O.ordStatus);
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        public string OrderNumGen(string name)
        {
            string answer = "";
            answer += name.Substring(0, 2).ToUpper();

            Random r = new Random();
            int num = r.Next(10000000, 100000000);

            answer += num.ToString();

            if (this.List().Where(x => x.ordNum == answer).FirstOrDefault() != null)
            {
                return OrderNumGen(name);
            }

            return answer;
        }

        //Add an Order to the DB
        public void AddToDB(Order o)
        {
            SqlCommand command = new
                            SqlCommand("INSERT INTO tblOrders (ordNum, ordCargo, ordQuantity, toDepot, fromDepot, custID, ordDate, ordStatus) " +
                                       "VALUES(@ordNum, @ordCargo, @ordQuantity, @toDepot, @fromDepot, @custID, @ordDate, @ordStatus) ;", conn);
            command.Parameters.AddWithValue("@ordNum", o.ordNum);
            command.Parameters.AddWithValue("@ordCargo", o.ordCargo);
            command.Parameters.AddWithValue("@ordQuantity", o.ordQuantity);
            command.Parameters.AddWithValue("@toDepot", o.toDepot);
            command.Parameters.AddWithValue("@fromDepot", o.fromDepot);
            command.Parameters.AddWithValue("@custID", o.custID);
            command.Parameters.AddWithValue("@ordDate", o.ordDate);
            command.Parameters.AddWithValue("@ordStatus", o.ordStatus);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        //Get a list of all orders
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
                o.custID = r.GetInt32(5).ToString();
                o.ordDate = r.GetDateTime(6);
                o.ordStatus = r.GetString(7);

                O_List.Add(o);
            }

            r.Close();
            command.Dispose();
            conn.Close();

            return O_List;
        }

        //Get a list of orders for a specific customer id
        public List<Order> List(string id)
        {
            conn.Open();

            String sql =
                "SELECT * " +
                "FROM tblOrders " +
                $"WHERE custID = '{id}'; ";

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
                o.custID = r.GetInt32(5).ToString();
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
