using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Exceptions
{
    internal sealed class AutorNotFoundException:DomainException
    {
        internal AutorNotFoundException(string message) : base(message){
        }
    }
}
