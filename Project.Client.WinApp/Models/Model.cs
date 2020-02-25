using System.Data;
using System.Data.SqlClient;
namespace Project.Client.WinApp.Models
{
    public class Model
    {
        private DatabaseConnection DatabaseConnection;
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

                return command.ExecuteNonQuery();
            }
        }
        protected object GetValue(string commandText, CommandType commandType = CommandType.Text, int commandTimeout = 60, params SqlParameter[] parameters)
        {
            using (var command = CreateCommand(DatabaseConnection.Connection, commandText, commandType, commandTimeout))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                Open(DatabaseConnection.Connection);

                return command.ExecuteScalar();
            }
        }

        private void Open(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

    }
}
