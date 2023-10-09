using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Interfaces
{
    public interface ICreate<T>
    {
        public Task<T> add(T entity);
    }
}
