using Crosscutting.Extensions;
using Domain.Autentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User).ToSnakeCase());
        
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName(nameof(User.Id).ToSnakeCase())
            .HasColumnType("CHAR(36)")
            .ValueGeneratedNever();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnName(nameof(User.Name).ToSnakeCase())
            .HasMaxLength(255);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnName(nameof(User.Email).ToSnakeCase())
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email)
            .IsUnique();
        
        builder.Property(u => u.UserName)
            .HasColumnName(nameof(User.UserName).ToSnakeCase())
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnName(nameof(User.PasswordHash).ToSnakeCase())
            .HasMaxLength(255);
        
        builder.Property(u => u.PhoneNumber)
            .HasColumnName(nameof(User.PhoneNumber).ToSnakeCase())
            .HasMaxLength(15)
            .IsRequired(false);
        
        builder.Property(u => u.SecurityStamp)
            .HasColumnName(nameof(User.SecurityStamp).ToSnakeCase())
            .HasMaxLength(36)
            .IsRequired(false);

        builder.Property(u => u.CreatedAt)
            .HasColumnName(nameof(User.CreatedAt).ToSnakeCase())
            .HasColumnType("DATETIME(6)")
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        builder.Property(u => u.UpdatedAt)
            .HasColumnName(nameof(User.UpdatedAt).ToSnakeCase())
            .HasColumnType("DATETIME(6)")
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6)");
        
        builder.HasMany(u => u.Meals)
            .WithOne(m => m.UserCreated)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}