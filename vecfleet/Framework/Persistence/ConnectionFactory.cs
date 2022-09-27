using System.Data.Common;
using Framework.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Framework.Persistence
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly ILogger<ConnectionFactory> _logger;
        private readonly string _connectionString;
        private readonly string _provider;
        public ConnectionFactory(ILogger<ConnectionFactory> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("vecfleet");
            _provider = configuration.GetSection("provider").Value;
        }

        public DbConnection CreateDbConnection()
        {
            _logger.LogInformation($"Creacion instancia DbConnection");
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            DbConnection? dbConnection;
            try
            {
                if (String.IsNullOrEmpty(_connectionString)) throw new Exception("No se puede generar DbConnection, falta connectionString");
                var factory = DbProviderFactories.GetFactory(_provider);
                dbConnection = factory.CreateConnection();
                if (dbConnection == null) throw new Exception("No se puede generar DbConnection, no se encuentra factory");
                dbConnection.ConnectionString = _connectionString;
                return dbConnection;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al generar instancia dbConnection");
                throw;
            }

        }
    }
}

