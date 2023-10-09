using AutoMapper;
using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using Softtek.Biblioteca.Domain.Interfaces;
using Softtek.Biblioteca.Infrastructure.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Infrastructure.Repositories
{
    internal class LibroRepository : ILibroRepository
    {
        private readonly DbTestBibliotecaSofttekContext _db;
        private readonly IMapper _mapper;
        public LibroRepository(DbTestBibliotecaSofttekContext db, IMapper mapper)
        {
            _db= db;
            _mapper= mapper;
        }

        public async Task<Libro> add(Libro entity)
        {
            try
            {
                _db.Libros.Add( _mapper.Map<Domain.Entities.Models.Libro>(entity));
                _db.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _db.Remove(id);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Libro> Get(int id)
        {
            try
            {
                return _mapper.Map<Libro>(_db.Libros.Where(x=>x.Id==id).FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Libro>> GetAll()
        {
            try
            {
                return _mapper.Map<List<Libro>>(_db.Libros.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Libro> update(Libro entity, int id)
        {
            try
            {
                _db.Update(entity);
                _db.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
