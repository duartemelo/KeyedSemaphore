using KeyedSemaphoreImplementation.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyedSemaphoreImplementation.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Don't remove! Important to set DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais, como chaves primárias compostas, índices, etc.
            base.OnModelCreating(modelBuilder);
        }
    }
}
