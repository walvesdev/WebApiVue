using Microsoft.EntityFrameworkCore;
using WebApiVueJs.AcessoDados.TypeConfiguration;
using WebApiVueJs.Model;

namespace WebApiVueJs.AcessoDados
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User Id=postgres;Password=123456;Host=localhost;Port=5432;Database=WebApi");
                       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new ClienteTypeConfiguration());
        }
    }
}
