using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Queries.ConfiguracionQueries
{
    internal class ConfiguracionQuery : IConfiguracionQuery
    {
        private readonly IConfiguracionRepository _configuracionRepository;

        public ConfiguracionQuery(IConfiguracionRepository configuracionRepository) {
            _configuracionRepository= configuracionRepository;
        }
        public Task<Configuracion> Get(int id)
        {
            return _configuracionRepository.Get(id);
        }

        public Task<List<Configuracion>> GetAll()
        {
            return _configuracionRepository.GetAll();
        }
    }
}
