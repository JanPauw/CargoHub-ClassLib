using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class Connection
    {
        private string cs = null;
        public SqlConnection conn;

        public Connection()
        {
            cs = @"YOUR_CONN_STRING";
            conn = new SqlConnection(cs);
        }
    }
}
