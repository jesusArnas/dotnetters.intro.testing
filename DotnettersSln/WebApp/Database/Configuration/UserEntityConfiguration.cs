using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Database.Entities;

namespace WebApp.Database.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .ToTable("users")
            .HasKey(x => x.Id);

        builder
            .Property(o => o.Name)
            .IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();

        builder
            .Property(o => o.Password)
            .IsRequired();
    }
}
