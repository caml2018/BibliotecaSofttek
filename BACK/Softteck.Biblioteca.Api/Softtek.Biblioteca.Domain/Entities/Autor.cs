using Softtek.Biblioteca.Domain.Bussines;
using Softtek.Biblioteca.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Entities
{
    public class Autor
    {
        public int id { get; set; }
        public string nombreCompleto { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string ciudadProcedencia { get; set; }
        public string correoElectronico { get; set; }

        public Autor validarAutorExiste(Autor autor, List<Autor> lstautores)
        {
            var respuesta = ValidarAutor.validarExiste(autor, lstautores);
            if (respuesta!=null)
            {
                return respuesta;
            }
            throw new AutorNotFoundException($"El autor no está registrado");
        }
    }
}
