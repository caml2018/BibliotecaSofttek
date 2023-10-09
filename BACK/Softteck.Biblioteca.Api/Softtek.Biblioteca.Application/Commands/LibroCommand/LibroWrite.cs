using Softtek.Biblioteca.Application.Interfaces;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Commands.LibroCommand
{
    internal class LibroWrite : ILibroWrite
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IConfiguracionRepository _configuracionRepository;
        private readonly Autor autor;

        public LibroWrite(ILibroRepository libroRepository, IAutorRepository autorRepository,
            Autor autor, IConfiguracionRepository configuracionRepository)
        {
            _libroRepository = libroRepository;
            _autorRepository = autorRepository;
            this.autor = autor;
            _configuracionRepository = configuracionRepository;
        }
        public async Task<Libro> add(Libro entity)
        {
            try
            {
                var lstautores = await _autorRepository.GetAll();
                var response = this.autor.validarAutorExiste(entity.Autor, lstautores);
                var candidad= await _configuracionRepository.Get(1);
                if (response != null)
                {
                    if (entity.ValidarCantidadLibros(await _libroRepository.GetAll(), candidad.numeroMaximoLibros))
                    {
                        entity.AutorId = response.id;
                        entity.Autor = null;
                        return await _libroRepository.add(entity);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            _libroRepository.Delete(id);
        }

        public async Task<Libro> update(Libro entity, int id)
        {
            return await _libroRepository.update(entity, id);
        }
    }
}
