using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Exceptions
{
    internal sealed class CantidaDeLibrosException: DomainException
    {
        internal CantidaDeLibrosException(string message) : base(message)
        {
        }
    }
}
