using System;
using System.Collections.Generic;

#nullable disable

namespace Softtek.Biblioteca.Domain.Entities.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string CorreoElectronico { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
