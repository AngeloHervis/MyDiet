using Crosscutting.DataHora;
using Domain._Base.Models;
using Domain.Autentication;
using Domain.Foods.Models;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class MyDietContext(DbContextOptions<MyDietContext> options) : DbContext(options)
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealItem> MealItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new UserMapping())
            .ApplyConfiguration(new MealMapping())
            .ApplyConfiguration(new MealItemMapping());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateEntityInCreate();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateEntityInCreate()
    {
        var entities = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: Entity, State: EntityState.Added })
            .Select(e => e.Entity)
            .ToList();

        foreach (var entity in entities)
        {
            Entry(entity).Property(nameof(Entity.CreatedAt)).CurrentValue = PadroesDataHora.Agora;
        }
    }
}