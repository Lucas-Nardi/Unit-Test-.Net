using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decola_Dev.Models
{
    public class Context : DbContext

    {
        public DbSet<Categoria> Categorias { get; set; } // Dizer para o banco que eu tenho uma tabela chamada catagorias
        public DbSet<Produto> Produtos { get; set; } // Dizer para o banco que eu tenho uma tabela chamada catagorias
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString:@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }


        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
