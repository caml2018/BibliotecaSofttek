using Microsoft.Extensions.DependencyInjection;
using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Infrastructure.Services.Service_Collections
{
    public static class ServiceCollectionsExtensionsInfrastructure
    {
        public static IServiceCollection AddServiceCollectionsInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<IConfiguracionRepository, ConfiguracionRepository>();
            return services;
        }
    }
}
