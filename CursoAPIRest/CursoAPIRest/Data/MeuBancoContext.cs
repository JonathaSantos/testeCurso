using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CursoAPIRest.Models;

namespace CursoAPIRest.Data
{
    public class MeuBancoContext : DbContext
    {
        public MeuBancoContext(DbContextOptions<MeuBancoContext> options)
            : base(options)
        {
        }

        public DbSet<CursoAPIRest.Models.Cidades> Cidades { get; set; }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
