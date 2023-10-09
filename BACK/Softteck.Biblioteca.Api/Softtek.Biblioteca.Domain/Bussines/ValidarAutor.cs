using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Bussines
{
    public static class ValidarAutor
    {
        public static Autor validarExiste(Autor autor, List<Autor> lstAutores)
        {
            var res= lstAutores.Where(x=>x.nombreCompleto.Equals(autor.nombreCompleto)).FirstOrDefault();
            if(res!=null)
                return res;
            return null;
        }
    }
}
