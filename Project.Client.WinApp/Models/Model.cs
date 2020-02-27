using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Project.Client.WinApp.Models
{
    public class Model
    {
        protected DatabaseConnection DatabaseConnection;

        public delegate void NewMessage();
        public event NewMessage OnNewMessage;

        public Model()
        {
            DatabaseConnection = DatabaseConnection.Instance;
        }

        public static SqlCommand CreateCommand(SqlConnection connection, string commandText, CommandType commandType = CommandType.Text, int commandTimeout = 60)
        {
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.CommandTimeout = commandTimeout;

            return command;
        }
        protected int Execute(string commandText, CommandType commandType = CommandType.Text, int commandTimeout = 60, params SqlParameter[] parameters)
        {
            using (var command = CreateCommand(DatabaseConnection.Connection, commandText, commandType, commandTimeout))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                Open(DatabaseConnection.Connection);

                Refresh(command);

                return command.ExecuteNonQuery();
            }
        }

        private void Refresh(SqlCommand sqlCommand)
        {
            SqlDependency.Stop(DatabaseConnection.ConnectionString);
            SqlDependency.Start(DatabaseConnection.ConnectionString);

            SqlDependency dependency = new SqlDependency(sqlCommand);
            dependency.OnChange += new OnChangeEventHandler(OnChange);
        }

        private void OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= OnChange;
            if (OnNewMessage != null)
            {
                OnNewMessage();
            }
        }

        ~Model()
        {
            SqlDependency.Stop(DatabaseConnection.ConnectionString);
        }
        protected SqlDataReader GetValue(string commandText, CommandType commandType = CommandType.Text, int commandTimeout = 60, params SqlParameter[] parameters)
        {
            using (var command = CreateCommand(DatabaseConnection.Connection, commandText, commandType, commandTimeout))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                Open(DatabaseConnection.Connection);
                Refresh(command);
                return command.ExecuteReader();
            }
        }

        protected void Open(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        protected void Close(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

    }
}
