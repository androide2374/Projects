using System;
using Entities.Models;
using Framework.Interfaces;
using Framework.Persistence;
using Microsoft.Extensions.Logging;
using Dapper;
using DapperExtensions;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ILogger<VehiculoRepository> _logger;
        private readonly vecfleetContext _context;
        private readonly IConnectionFactory _readOnlyConnection;

        public VehiculoRepository(ILogger<VehiculoRepository> logger, vecfleetContext context, IConnectionFactory readOnlyConnection)
        {
            _logger = logger;
            _context = context;
            _readOnlyConnection = readOnlyConnection;
        }



        public async Task<bool> AddAsync(Vehiculo entity)
        {
            try
            {
                entity.FechaRegistro = DateTime.Now;

                var result = await _context.Vehiculos.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vehiculo =  await _context.Vehiculos.FirstOrDefaultAsync(x => x.Id == id);
            if (vehiculo == null) return false;
            var result = _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            try
            {

                using (var connection = _readOnlyConnection.CreateDbConnection())
                {
                    await connection.OpenAsync();
                    string sql = @$"SELECT * 
                                    from Vehiculos V
                                    INNER JOIN TipoVehiculo TV on TV.id=v.idTipoVehiculo";
                    var listaVehiculos = connection.Query<Vehiculo, TipoVehiculo, Vehiculo>(sql, (vehiculo, tipoVehiculo) =>
                    {
                        vehiculo.TipoVehiculo = tipoVehiculo;
                        return vehiculo;
                    });
                    return listaVehiculos;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el listado de vehiculos");
                throw;
            }
        }

        public async Task<Vehiculo> GetByIdAsync(int id)
        {
            using (var connection = _readOnlyConnection.CreateDbConnection())
            {
                await connection.OpenAsync();
                string sql = @$"SELECT * 
                                from Vehiculos V
                                INNER JOIN TipoVehiculo TV on TV.id=v.idTipoVehiculo
                                WHERE V.id={id}";
                
                var listaVehiculos = connection.Query<Vehiculo, TipoVehiculo, Vehiculo>(sql, (vehiculo, tipoVehiculo) =>
                {
                    vehiculo.TipoVehiculo = tipoVehiculo;
                    return vehiculo;
                });
                return listaVehiculos.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateAsync(Vehiculo entity)
        {
            try
            {
                var vehiculo= await _context.Vehiculos.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (vehiculo == null)
                {
                    return false;
                }
                vehiculo.Anio = entity.Anio;
                vehiculo.CantidadRuedas = entity.CantidadRuedas;
                vehiculo.Marca = entity.Marca;
                vehiculo.Modelo = entity.Modelo;
                vehiculo.Chasis = entity.Chasis;
                vehiculo.KmsProximoMantenimiento = entity.KmsProximoMantenimiento;
                vehiculo.KmsRecorrido = entity.KmsRecorrido;
                vehiculo.IdTipoVehiculo = entity.IdTipoVehiculo;

               var result = _context.Update(vehiculo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar vehiculo");
                throw;
            }
        }
    }
}

