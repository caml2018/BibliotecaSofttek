using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Interfaces
{
    public interface IDelete<Tid>
    {
        public void Delete(Tid id);
    }
}
