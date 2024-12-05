using Aware.Dependency;
using Aware.Data;
using TicketSales.WebApi.Data;
using TicketSales.WebApi.BusinessLogic.Services;

namespace TicketSales.WebApi.BusinessLogic.Dependency;

public class LibraryInstaller : AwareDependencyInstaller
{
    public override void Install(IServiceCollection services, bool isLite)
    {
        services.AddSingleton(typeof(IDbContextFactory), typeof(DbContextFactory<TicketSalesDbContext>));
        base.InstallWithEF<TicketSalesDbContext>(services, isLite);
        services.AddSingleton<IEventService, EventService>();
    }
}