using Microsoft.Extensions.DependencyInjection;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Services.Service_Collections
{
    public static class ServiceCollectionExtensionsDomain
    {
        public static IServiceCollection AddServiceCollectionsDomain(this IServiceCollection services)
        {
            services.AddScoped<Autor>();
            services.AddScoped<Libro>();
            services.AddScoped<Configuracion>();
            return services;
        }
    }
}
