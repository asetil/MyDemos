using Aware.Dependency;
using System.Reflection;
using TicketSales.WebApi.Data;

namespace TicketSales.WebApi.BusinessLogic.Dependency;

public class LibraryInstaller : AwareDependencyInstaller
{
    /// <summary>
    /// //Add Aware functionality here
    /// !!! Aware does not aim to control or hide coding logic in the background or limit you with its rules.
    /// !!! Its purpose is to accelerate the project development process by providing a foundation for the most critical stages
    /// !!! and equipping you with the necessary software tools and functionalities.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <param name="callerAssembly"></param>
    public void Arrange(IServiceCollection services, IConfiguration configuration, Assembly callerAssembly)
    {
        Install(services, configuration, callerAssembly)
            .WithMenuManagement(services, Settings.ServiceLifetime)
            .WithSliderManagement(services, Settings.ServiceLifetime)
            .WithEntityFramework<TicketSalesDbContext>(services)
            .WithJwtAuthentication(services, configuration);

        services.AddAuthorization();
    }
}