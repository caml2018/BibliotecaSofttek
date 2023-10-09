using Microsoft.EntityFrameworkCore;
using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using Softtek.Biblioteca.Infrastructure.IMDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Infrastructure.Repositories
{
    internal class ConfiguracionRepository : IConfiguracionRepository
    {
        private readonly PersistenceContext _persistenceContext;

        public ConfiguracionRepository(PersistenceContext persistenceContext) { 
            _persistenceContext= persistenceContext;
        }
        public async Task<Configuracion> add(Configuracion entity)
        {
            entity.id = 1;
            var auxentity = _persistenceContext.congifuracion.Where(x => x.id == entity.id).FirstOrDefault();
            if (auxentity == null)
                _persistenceContext.Add(entity);
            else
            {
                auxentity.numeroMaximoLibros = entity.numeroMaximoLibros;
                _persistenceContext.congifuracion.Attach(auxentity);
                _persistenceContext.Entry(auxentity).Property(p=>p.numeroMaximoLibros).IsModified=true;
            }
                
            _persistenceContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Configuracion> Get(int id)
        {
            return _persistenceContext.congifuracion.Where(x => x.id == id).FirstOrDefault();
        }

        public async Task<List<Configuracion>> GetAll()
        {
            return _persistenceContext.congifuracion.ToList();
        }

        public Task<Configuracion> update(Configuracion entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
