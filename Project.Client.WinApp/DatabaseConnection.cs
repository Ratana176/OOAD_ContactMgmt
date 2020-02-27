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
        private readonly SqlConnection _sqlConnection;
        private static DatabaseConnection _instance;
        private string connection;
        private DatabaseConnection()
        {
            try
            {
                connection = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                this._sqlConnection = new SqlConnection(connection);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        //private static readonly Lazy<DatabaseConnection> lazy = new Lazy<DatabaseConnection>(() => new DatabaseConnection());
        //public static DatabaseConnection Instance => lazy.Value;

        public SqlConnection Connection => _sqlConnection;

        public string ConnectionString => connection;

        public static DatabaseConnection Instance
        {
            get { return _instance ?? (_instance = new DatabaseConnection()); }
        }

        public bool Open()
        {
            try
            {
                _sqlConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public bool Close()
        {
            if (_sqlConnection.State != System.Data.ConnectionState.Open) return false;
            _sqlConnection.Close();
            return true;
        }

    }
}
