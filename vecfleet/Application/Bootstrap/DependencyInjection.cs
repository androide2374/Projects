using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Boopstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service, IConfiguration configuration)
        {
            return service;
        }
    }
}

