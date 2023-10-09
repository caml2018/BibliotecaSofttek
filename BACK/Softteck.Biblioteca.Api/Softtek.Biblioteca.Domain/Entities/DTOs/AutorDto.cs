using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Entities.DTOs
{
    public class AutorDto
    {
        public string nombreCompleto { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string ciudadProcedencia { get; set; }
        public string correoElectronico { get; set; }
    }
}
