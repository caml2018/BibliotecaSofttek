using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Commands.AutorCommand
{
    internal class AutorWrite : IAutorWrite
    {
        private readonly IAutorRepository _autorRepository;

        public AutorWrite(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<Autor> add(Autor entity)
        {
            return await _autorRepository.add(entity);
        }

        public void Delete(int id)
        {
            _autorRepository.Delete(id);
        }

        public async Task<Autor> update(Autor entity, int id)
        {
            return await _autorRepository.update(entity, id);
        }
    }
}
