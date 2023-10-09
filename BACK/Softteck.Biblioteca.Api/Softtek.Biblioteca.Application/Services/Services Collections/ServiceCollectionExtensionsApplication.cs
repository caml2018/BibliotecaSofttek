using Microsoft.Extensions.DependencyInjection;
using Softtek.Biblioteca.Application.Commands.AutorCommand;
using Softtek.Biblioteca.Application.Commands.ConfiguracionCommand;
using Softtek.Biblioteca.Application.Commands.LibroCommand;
using Softtek.Biblioteca.Application.Queries.AutorQueries;
using Softtek.Biblioteca.Application.Queries.ConfiguracionQueries;
using Softtek.Biblioteca.Application.Queries.LibroQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Services.Services_Collections
{
    public static class ServiceCollectionExtensionsApplication
    {
        public static IServiceCollection AddServiceCollectionsApplication(this IServiceCollection services)
        {
            services.AddScoped<IAutorWrite, AutorWrite>();
            services.AddScoped<IAutorQuery, AutorQuery>();
            services.AddScoped<ILibroWrite, LibroWrite>();
            services.AddScoped<ILibroQuery, LibroQuery>();
            services.AddScoped<IConfiguracionWrite, ConfiguracionWrite>();
            services.AddScoped<IConfiguracionQuery, ConfiguracionQuery>();
            return services;
        }
    }
}
