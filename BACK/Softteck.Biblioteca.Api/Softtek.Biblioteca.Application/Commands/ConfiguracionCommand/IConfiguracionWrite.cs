using Softtek.Biblioteca.Domain.Entities;
using Softtek.Biblioteca.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Application.Commands.ConfiguracionCommand
{
    public interface IConfiguracionWrite:IBaseCommand<Configuracion,int>
    {
    }
}
