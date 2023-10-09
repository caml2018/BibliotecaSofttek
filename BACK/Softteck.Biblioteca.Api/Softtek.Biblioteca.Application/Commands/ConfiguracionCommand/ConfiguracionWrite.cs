using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Commands.ConfiguracionCommand
{
    internal class ConfiguracionWrite : IConfiguracionWrite
    {
        private readonly IConfiguracionRepository _configuracionRepository;

        public ConfiguracionWrite(IConfiguracionRepository configuracionRepository)
        {
            _configuracionRepository= configuracionRepository;
        }

        public Task<Configuracion> add(Configuracion entity)
        {
            return _configuracionRepository.add(entity);
        }

        public void Delete(int id)
        {
            _configuracionRepository.Delete(id);
        }

        public Task<Configuracion> update(Configuracion entity, int id)
        {
            return _configuracionRepository.update(entity,id);
        }
    }
}
