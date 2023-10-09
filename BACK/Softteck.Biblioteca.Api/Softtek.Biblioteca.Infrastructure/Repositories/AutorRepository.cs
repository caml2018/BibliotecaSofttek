using AutoMapper;
using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using Softtek.Biblioteca.Infrastructure.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Infrastructure.Repositories
{
    internal class AutorRepository : IAutorRepository
    {
        private readonly DbTestBibliotecaSofttekContext _db;
        private readonly IMapper _mapper;
        public AutorRepository(DbTestBibliotecaSofttekContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Autor> add(Autor entity)
        {
            try
            {
                _db.Autors.Add(_mapper.Map<Domain.Entities.Models.Autor>(entity));
                _db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
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
                throw;
            }
        }

        public async Task<Autor> Get(int id)
        {
            try
            {
                return _mapper.Map<Autor>(_db.Autors.Where(x => x.Id == id).FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Autor>> GetAll()
        {
            try
            {
                return _mapper.Map<List<Autor>>(_db.Autors.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Autor> update(Autor entity, int id)
        {
            try
            {
                _db.Autors.Update(_mapper.Map<Domain.Entities.Models.Autor>(entity));
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
