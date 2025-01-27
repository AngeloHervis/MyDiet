using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class MyDietContext : DbContext
{
    public MyDietContext(DbContextOptions<MyDietContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}