using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable(nameof(User));

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("CHAR(36)")
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnType("VARCHAR(90)")
                .HasMaxLength(90)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("VARCHAR(24)")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}