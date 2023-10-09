using System;
using System.Collections.Generic;

#nullable disable

namespace Softtek.Biblioteca.Domain.Entities.Models
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public int? NumeroPaginas { get; set; }
        public int? AutorId { get; set; }

        public virtual Autor Autor { get; set; }
    }
}
