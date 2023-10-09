using Softtek.Biblioteca.Domain.Bussines;
using Softtek.Biblioteca.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Entities
{
    public class Libro
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int año { get; set; }
        public string genero { get; set; }
        public int numeroPaginas { get; set; }
        public int? AutorId { get; set; }
        public int? CantidadMaximaDeLibros { get; set; }
        public Autor Autor { get; set; }

        public bool ValidarCantidadLibros(List<Libro> lstlibros,int cantidadMaximaDeLibros)
        {
            if (lstlibros.Count >= cantidadMaximaDeLibros)
                throw new CantidaDeLibrosException("No es posible registrar el libro, se alcanzó el máximo permitido");
            return true;

        }

    }
}
