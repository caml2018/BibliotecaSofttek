using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Softtek.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Infrastructure.IMDataAccess
{
    public class PersistenceContext: DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options){ }

        public DbSet<Configuracion> congifuracion { get; set; } = null!;
    }
}
