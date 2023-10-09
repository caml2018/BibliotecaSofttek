using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Queries.LibroQueries
{
    internal class LibroQuery : ILibroQuery
    {
        private readonly ILibroRepository _libroRepository;

        public LibroQuery(ILibroRepository libroRepository)
        {
            _libroRepository= libroRepository;
        }
        public async Task<Libro> Get(int id)
        {
            return await _libroRepository.Get(id);  
        }

        public async Task<List<Libro>> GetAll()
        {
            return await _libroRepository.GetAll();
        }
    }
}
