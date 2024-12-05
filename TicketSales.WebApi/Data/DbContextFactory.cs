using Aware.Data;
using Microsoft.EntityFrameworkCore;

namespace TicketSales.WebApi.Data;

public class DbContextFactory<T> : IDbContextFactory where T : DbContext
{
    private readonly IServiceProvider _serviceProvider;

    public DbContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public DbContext GetDbContext()
    {
        var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<T>();
        return dbContext;
    }
}
