using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Entities.DTOs
{
    public class LibroDto
    {
        public string titulo { get; set; }
        public int año { get; set; }
        public string genero { get; set; }
        public int numeroPaginas { get; set; }
        public Autor Autor { get; set; }
    }
}
