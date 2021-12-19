using Manager.Domain.Entities;
using Manager.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infrastructure
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}