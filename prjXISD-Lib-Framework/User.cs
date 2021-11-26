using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    public class User
    {
        //SQL Server Connection
        private static Connection c = new Connection();
        private static SqlConnection conn = c.conn;

        //Encryption Class
        private static Encrypt e = new Encrypt();

        #region Global Variables
        private string username;
        private string password;
        private string encPassword;
        private string empNum;
        #endregion

        #region Getters and Setters
        public string Username { get => username; set => username = value; }
        private string Password { get => password; set => password = value; }
        public string EmpNum { get => empNum; set => empNum = value; }
        private string EncPassword { get => encPassword; set => encPassword = value; }
        #endregion

        #region Constructors
        //Construtor with Values
        public User(string u_name, string p_word, string e_num)
        {
            this.Username = u_name;
            this.Password = p_word;
            this.EmpNum = e_num;
        }

        //Construtor without Values
        public User()
        {

        }
        #endregion

        #region Login
        //Login Method
        public User login()
        {
            //Encrypt Password before continuing
            this.EncPassword = e.EncryptString(this.Password);
            User temp;

            try
            {
                conn.Open();

                String sql =
                    "SELECT * " +
                    "FROM tblUsers " +
                    "WHERE Username = '" + this.Username + "' " +
                    "AND Password = '" + this.EncPassword + "' " +
                    "AND empNum ='" + this.empNum + "' ;";

                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader r = command.ExecuteReader();

                r.Read();

                if (r.HasRows)
                {
                    temp = this;
                }
                else
                {
                    temp = null;
                }

                r.Close();
                command.Dispose();
                conn.Close();

                return temp;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        #endregion

        #region Register
        //Register Method
        public User register()
        {
            this.EncPassword = e.EncryptString(this.Password);

            //Try to write new details to DB
            try
            {
                conn.Open();

                SqlCommand command = new
                            SqlCommand("INSERT INTO tblUsers (Username, Password, empNum) " +
                                       "VALUES(@Username, @Password, @empNum) ;", conn);
                command.Parameters.AddWithValue("@Username", this.Username);
                command.Parameters.AddWithValue("@Password", this.EncPassword);
                command.Parameters.AddWithValue("@empNum", this.EmpNum);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                adapter.Dispose();

                conn.Close();
            }
            catch (Exception)
            {
                //Returns Null on error
                return null;
            }

            //Returns a User with details
            return this;
        }

        //User Exists
        public bool UsernameExists()
        {
            bool answer;

            try
            {
                conn.Open();

                String sql =
                    "SELECT * " +
                    "FROM tblUsers " +
                    "WHERE Username = '" + this.Username + "';";

                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader r = command.ExecuteReader();

                //Read from Query Results
                r.Read();

                if (r.HasRows) //If there are Results
                {
                    answer = true; //User Exists
                }
                else
                {
                    answer = false; //User does not Exist
                }

                //Close Connections
                r.Close();
                command.Dispose();
                conn.Close();

                return answer; //Return final answer
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Valid Register Username
        public bool regValidUsername()
        {
            //Check if User already Exists
            if (UsernameExists())
            {
                return false;
            }

            //Username String for easier usage in code
            string n = this.Username;

            //(Null or Whitespace Username) or (Min length of 4 Characters)
            if ((string.IsNullOrWhiteSpace(n)) || (n.Length < 4))
            {
                return false;
            }

            //All tests passed return "Valid Username"
            return true;
        }

        //Valid Register Password || https://www.c-sharpcorner.com/uploadfile/jitendra1987/password-validator-in-C-Sharp/ ||
        public bool regValidPassword()
        {
            //Username String for easier usage in code
            string p = this.Password;

            int validConditions = 0;
            foreach (char c in p)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }

            foreach (char c in p)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }

            if (validConditions == 0) return false;

            foreach (char c in p)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }

            if (validConditions == 1) return false;

            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever    
                if (p.IndexOfAny(special) == -1) return false;
            }

            return true;
        }

        //Valid Registering Employee Number
        public bool regValidEmpNum()
        {
            bool EmpNumExists;
            bool EmpNumInUse;

            //Check that EmpNum actually Exists
            try
            {
                conn.Open();

                String sql =
                    "SELECT * " +
                    "FROM tblEmployees " +
                    "WHERE empNum = '" + this.EmpNum + "';";

                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader r = command.ExecuteReader();

                //Read from Query Results
                r.Read();

                if (r.HasRows) //If there are Results
                {
                    EmpNumExists = true; //Employee Exists
                }
                else
                {
                    EmpNumExists = false; //Employee does not Exist
                }

                //Close Connections
                r.Close();
                command.Dispose();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

            //Check that EmpNum is not Already Registered
            try
            {
                conn.Open();

                String sql =
                    "SELECT * " +
                    "FROM [tblUsers] " +
                    "WHERE [empNum] = '" + this.EmpNum + "';";

                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader r = command.ExecuteReader();

                //Read from Query Results
                r.Read();

                if (r.HasRows) //If there are Results
                {
                    EmpNumInUse = true; //Employee Exists
                }
                else
                {
                    EmpNumInUse = false; //Employee does not Exist
                }

                //Close Connections
                r.Close();
                command.Dispose();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

            if (EmpNumExists == true && EmpNumInUse == false)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
