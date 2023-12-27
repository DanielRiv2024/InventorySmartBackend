using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace InventorySmart
{
    public class OracleConecctionManager
    {
        private readonly IConfiguration _configuration;

        public OracleConecctionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<OracleConnection> OpenConnectionAsync()
        {
            var connectionString = _configuration["OracleInventoryConecction"];
            var connection = new OracleConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public void CloseConnection(OracleConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
