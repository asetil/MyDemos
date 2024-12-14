using Aware.Auth;
using Aware.Model;

namespace TicketSales.WebApi.BusinessLogic.Util;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            AddAdminUser(services);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }

    public static void AddAdminUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<IUserManager>();
        if (!userManager.Any(a => a.Email == "admin@ticketsales.com"))
        {
            userManager.Save(new UserItemDto
            {
                Name = "Admin User",
                Email = "admin@ticketsales.com",
                Password = "admin",
                Role = Aware.Util.Enum.UserRole.Admin
            });
        }
    }
}
