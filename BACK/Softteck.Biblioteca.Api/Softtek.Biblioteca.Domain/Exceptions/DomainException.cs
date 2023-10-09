using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Exceptions
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage): base(businessMessage){
        }
    }
}
