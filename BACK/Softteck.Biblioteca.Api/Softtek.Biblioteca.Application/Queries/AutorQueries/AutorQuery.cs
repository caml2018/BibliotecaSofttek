using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Queries.AutorQueries
{
    internal class AutorQuery : IAutorQuery
    {
        private readonly IAutorRepository _autorRepository;
        public AutorQuery(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;     
        }
        public async Task<Autor> Get(int id)
        {
            return await _autorRepository.Get(id);
        }

        public async Task<List<Autor>> GetAll()
        {
            return await _autorRepository.GetAll();
        }
    }
}
