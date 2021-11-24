using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    class Connection
    {
        private string cs = null;
        public SqlConnection conn;

        public Connection()
        {
            cs = @"Server=tcp:devhub.database.windows.net,1433;Initial Catalog=cargohub;Persist Security Info=False;User ID=devhub;Password=,,PassnowSQL1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            conn = new SqlConnection(cs);
        }
    }
}
