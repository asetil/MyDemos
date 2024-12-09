using Aware.Dependency;
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
    /// <param name="dependencySetting"></param>
    /// <param name="configuration"></param>
    public void Arrange(IServiceCollection services, DependencySetting dependencySetting, IConfiguration configuration)
    {

        base.Install(services, dependencySetting);
        base.InstallEntityFramework<TicketSalesDbContext>(services);

        AddJwtAuthentication(services, configuration);
    }
}