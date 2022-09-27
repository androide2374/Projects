using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Boopstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<vecfleetContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("vecfleet"));
            });
            return service;
        }
    }
}

