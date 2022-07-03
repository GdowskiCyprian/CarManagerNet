using System.Data;
using MySql.Data.MySqlClient;

namespace CarManagerNet.SqlProvider;

public class MySqlProvider
{
    #region fields
        private readonly string _connectionString;
        private readonly int _commandTimeout;
        private readonly List<MySqlParameter> _sqlParameters = new List<MySqlParameter>();
        #endregion

        #region constructors

        public MySqlProvider()
        {
            _commandTimeout = 1800;
            
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "carmanagerdatabase.mysql.database.azure.com",
                Database = "carmanager",
                UserID = "Savadrox",
                Password = "Plokiploki1!",
                SslMode = MySqlSslMode.Required,
                SslCa = "DigiCertGlobalRootCA.crt.pem"
            };
            _connectionString = builder.ConnectionString;
        }
        #endregion

        #region methods
        public MySqlParameter AddSqlParameter(
            string parameterName,
            object value,
            MySqlDbType sqlDbType,
            ParameterDirection direction,
            int size = 0)
        {
            var newSqlParameter = new MySqlParameter()
            {
                ParameterName = parameterName,
                Value = value,
                MySqlDbType = sqlDbType,
                Direction = direction,
                Size = size
            };

            _sqlParameters.Add(newSqlParameter);

            return newSqlParameter;
        }

        public void ExecuteNonQuery(string procedure)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            using (var dataAdapter = new MySqlDataAdapter(command))
            {
                try
                {
                    command.CommandTimeout = _commandTimeout;
                    command.CommandText = procedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(_sqlParameters.ToArray());
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    _sqlParameters.Clear();
                }
            }
        }
        
        public void ExecuteCustomNonQuery(string query)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            using (var dataAdapter = new MySqlDataAdapter(command))
            {
                try
                {
                    command.CommandTimeout = _commandTimeout;
                    command.CommandText = query;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void ExecuteQuery(out DataTable dataTable, string procedure)
        {
            dataTable = new DataTable();

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            using (var dataAdapter = new MySqlDataAdapter(command))
            {
                try
                {
                    command.CommandTimeout = _commandTimeout;
                    command.CommandText = procedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(_sqlParameters.ToArray());
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    dataAdapter.Fill(dataTable);
                }
                finally
                {
                    connection.Close();
                    _sqlParameters.Clear();
                }
            }
        }

        public void ExecuteCustomQuery(out DataTable dataTable, string query)
        {
            dataTable = new DataTable();
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            using (var dataAdapter = new MySqlDataAdapter(command))
            {
                try
                {
                    command.CommandTimeout = _commandTimeout;
                    command.CommandText = query;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    dataAdapter.Fill(dataTable);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion
}