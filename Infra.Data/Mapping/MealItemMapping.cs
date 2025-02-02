using Crosscutting.Extensions;
using Domain.Foods.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping;

public class MealItemMapping : IEntityTypeConfiguration<MealItem>
{
    public void Configure(EntityTypeBuilder<MealItem> builder)
    {
        builder.ToTable(nameof(MealItem).ToSnakeCase());

        builder.HasKey(mi => mi.Id);

        builder.Property(mi => mi.Id)
            .HasColumnName(nameof(MealItem.Id).ToSnakeCase())
            .ValueGeneratedNever();

        builder.Property(mi => mi.Name)
            .HasColumnName(nameof(MealItem.Name).ToSnakeCase())
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(mi => mi.Description)
            .HasColumnName(nameof(MealItem.Description).ToSnakeCase())
            .HasMaxLength(255);

        builder.Property(mi => mi.Calories)
            .HasColumnName(nameof(MealItem.Calories).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(mi => mi.Protein)
            .HasColumnName(nameof(MealItem.Protein).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(mi => mi.Carbs)
            .HasColumnName(nameof(MealItem.Carbs).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(mi => mi.Fat)
            .HasColumnName(nameof(MealItem.Fat).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder.Property(mi => mi.Quantity)
            .HasColumnName(nameof(MealItem.Quantity).ToSnakeCase())
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder.Property(mi => mi.MealId)
            .HasColumnName(nameof(MealItem.MealId).ToSnakeCase())
            .IsRequired();
        
        builder.HasOne(mi => mi.Meal)
            .WithMany(m => m.MealItems)
            .HasForeignKey(mi => mi.MealId);
    }
}