using Crosscutting.Extensions;
using Domain.Foods.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping;

public class MealMapping : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable(nameof(Meal).ToSnakeCase());

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName(nameof(Meal.Id).ToSnakeCase())
            .ValueGeneratedNever();

        builder.Property(m => m.Name)
            .HasColumnName(nameof(Meal.Name).ToSnakeCase())
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(m => m.Description)
            .HasColumnName(nameof(Meal.Description).ToSnakeCase())
            .HasMaxLength(255);

        builder.Property(m => m.Calories)
            .HasColumnName(nameof(Meal.Calories).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(m => m.Protein)
            .HasColumnName(nameof(Meal.Protein).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(m => m.Carbs)
            .HasColumnName(nameof(Meal.Carbs).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(m => m.Fat)
            .HasColumnName(nameof(Meal.Fat).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder.Property(m => m.Quantity)
            .HasColumnName(nameof(Meal.Quantity).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder.Property(m => m.UserId)
            .HasColumnName(nameof(Meal.UserId).ToSnakeCase())
            .IsRequired();
        
        builder.HasOne(m => m.UserCreated)
            .WithMany(u => u.Meals)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.MealItems)
            .WithOne(mi => mi.Meal)
            .HasForeignKey(mi => mi.MealId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}