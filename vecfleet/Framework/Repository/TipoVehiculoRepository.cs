using System;
using Dapper;
using DapperExtensions;
using Entities.Models;
using Framework.Interfaces;
using Framework.Persistence;
using Microsoft.Extensions.Logging;

namespace Framework.Repository
{
    public class TipoVehiculoRepository : ITipoVehiculoRepository
    {
        private readonly ILogger<TipoVehiculoRepository> _logger;
        private readonly vecfleetContext _context;
        private readonly IConnectionFactory _readOnlyConnection;

        public TipoVehiculoRepository(ILogger<TipoVehiculoRepository> logger, vecfleetContext context, IConnectionFactory readOnlyConnection)
        {
            _logger = logger;
            _context = context;
            _readOnlyConnection = readOnlyConnection;
        }

        public Task<bool> AddAsync(TipoVehiculo entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipoVehiculo>> GetAllAsync()
        {
            try
            {

                using (var connection = _readOnlyConnection.CreateDbConnection())
                {
                    await connection.OpenAsync();
                    return await connection.GetListAutoMapAsync<TipoVehiculo>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el listado de vehiculos");
                throw;
            }
        }

        public Task<TipoVehiculo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TipoVehiculo entity)
        {
            throw new NotImplementedException();
        }
    }
}

