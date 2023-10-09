using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Domain.Interfaces.Base
{
    public interface IBaseCommand <T,Tid>:ICreate<T>,IDelete<Tid>,IUpdate<T,Tid>
    {
    }
}
