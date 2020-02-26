using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Client.WinApp
{
    public class DatabaseConnection
    {
        private SqlConnection SqlConnection;
        private static DatabaseConnection instance;
        private DatabaseConnection()
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                this.SqlConnection = new SqlConnection(connection);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        //private static readonly Lazy<DatabaseConnection> lazy = new Lazy<DatabaseConnection>(() => new DatabaseConnection());
        //public static DatabaseConnection Instance => lazy.Value;

        public SqlConnection Connection => SqlConnection;

        public static DatabaseConnection Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }

        public Boolean Open()
        {
            try
            {
                SqlConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public Boolean Close()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
                return true;
            }
            return false;
        }

    }
}
