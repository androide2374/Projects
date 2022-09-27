using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Framework.Interfaces;
using Framework.Repository;

namespace Framework.Boopstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFramework(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<vecfleetContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("vecfleet"));

            });
            service.AddTransient<IConnectionFactory, ConnectionFactory>();
            service.AddTransient<IVehiculoRepository, VehiculoRepository>();
            service.AddTransient<ITipoVehiculoRepository, TipoVehiculoRepository>();
            return service;
        }
    }
}

