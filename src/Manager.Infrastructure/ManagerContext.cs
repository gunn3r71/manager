using System;
using Manager.Domain.Entities;
using Manager.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infrastructure
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {
        }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var connectionString = @"Server=localhost;Database=Manager;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString, x =>
            {
                x.EnableRetryOnFailure(3, new TimeSpan(0, 0, 0, 30), null);
                x.CommandTimeout(30);
                x.MigrationsHistoryTable("Migrations");
                x.MigrationsAssembly(typeof(ManagerContext).Assembly.FullName);
            });
        }
    }
}