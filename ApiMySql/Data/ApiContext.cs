using ApiMySql.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiMySql.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            InsertData();
        }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("t_clientes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
            });


            
        }

        private void InsertData()
        {
            // Creates the database if not exists
            Database.EnsureCreated();
        }
    }
}