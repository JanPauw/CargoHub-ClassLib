using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class TruckList
    {
        private List<Truck> T_List = new List<Truck>();
        private static Connection c = new Connection();
        SqlConnection conn = c.conn;

        public void UpdateTruck(Truck t)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE tblVehicles " +
                "SET vehType = @vehType, vehManufacturer = @vehManufacturer, vehEngineSize = @vehEngineSize, vehOdoReading = @vehOdoReading, vehNextService = @vehNextService, vehStatus = @vehStatus, empNum = @empNum " +
                $"WHERE vehRegNum = {t.vehRegNum};", conn);

            command.Parameters.AddWithValue("@vehType", t.vehType);
            command.Parameters.AddWithValue("@vehManufacturer", t.vehManufacturer);
            command.Parameters.AddWithValue("@vehEngineSize", t.vehEngineSize);
            command.Parameters.AddWithValue("@vehOdoReading", t.vehOdoReading);
            command.Parameters.AddWithValue("@vehNextService", t.vehNextService);
            command.Parameters.AddWithValue("@vehStatus", t.vehStatus);
            command.Parameters.AddWithValue("@empNum", t.empNum);
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();

            conn.Close();
        }

        //Add an Order to the DB
        public void AddToDB(Truck t)
        {
            if (this.List().Where(x => x.vehRegNum == t.vehRegNum).FirstOrDefault() == null)
            {
                SqlCommand command = new
                                            SqlCommand("INSERT INTO tblVehicles (vehRegNum, vehType, vehManufacturer, vehEngineSize, vehOdoReading, vehNextService, vehStatus, empNum) " +
                                                       "VALUES(@vehRegNum, @vehType, @vehManufacturer, @vehEngineSize, @vehOdoReading, @vehNextService, @vehStatus, @empNum) ;", conn);
                command.Parameters.AddWithValue("@vehRegNum", t.vehRegNum);
                command.Parameters.AddWithValue("@vehType", t.vehType);
                command.Parameters.AddWithValue("@vehManufacturer", t.vehManufacturer);
                command.Parameters.AddWithValue("@vehEngineSize", t.vehEngineSize);
                command.Parameters.AddWithValue("@vehOdoReading", t.vehOdoReading);
                command.Parameters.AddWithValue("@vehNextService", t.vehNextService);
                command.Parameters.AddWithValue("@vehStatus", t.vehStatus);
                command.Parameters.AddWithValue("@empNum", t.empNum);

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                adapter.Dispose();

                conn.Close();
            }
        }

        //Get a list of all orders
        public List<Truck> List()
        {
            conn.Open();

            String sql =
                "SELECT * " +
                "FROM tblVehicles; ";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader r = command.ExecuteReader();

            T_List.Clear();

            while (r.Read())
            {
                Truck t = new Truck();

                t.vehRegNum = r.GetString(0);
                t.vehType = r.GetString(1);
                t.vehManufacturer = r.GetString(2); ;
                t.vehEngineSize = r.GetString(3); ;
                t.vehOdoReading = r.GetString(4); ;
                t.vehNextService = r.GetString(5); ;
                t.vehStatus = r.GetString(6); ;
                t.empNum = r.GetString(7);

                T_List.Add(t);
            }

            r.Close();
            command.Dispose();
            conn.Close();

            return T_List;
        }
    }
}
