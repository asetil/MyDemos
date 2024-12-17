using Aware.Data;
using Microsoft.EntityFrameworkCore;
using TicketSales.WebApi.Data.Entity;

namespace TicketSales.WebApi.Data;

public class TicketSalesDbContext : AwareDbContext<TicketSalesDbContext>
{
    public TicketSalesDbContext(DbContextOptions<TicketSalesDbContext> options) : base(options)
    {
    }

    public DbSet<EventEntity> Event { get; set; }
    public DbSet<PlaceEntity> Place { get; set; }
    public DbSet<EventPlaceEntity> EventPlace { get; set; }
    public DbSet<EventPerformerEntity> EventPerformer { get; set; }
    public DbSet<EventEvaluationEntity> EventEvaluation { get; set; }
    public DbSet<EventOrganizerEntity> EventOrganizer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply global configuration for all DateTime properties
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetColumnType("timestamp without time zone");
                }
            }
        }


        //Apply outer configuration
        //modelBuilder.ApplyConfiguration(new EventEntityConfigurations());
        
        modelBuilder.Entity<EventEntity>().Property(p => p.Name).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<EventEntity>().HasOne(p => p.Organizer).WithMany().HasForeignKey(p => p.OrganizerId);

        modelBuilder.Entity<PlaceEntity>().Property(p => p.Name).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<EventPlaceEntity>().Property(p => p.StartDate).IsRequired();
        modelBuilder.Entity<EventPlaceEntity>().Property(p => p.EndDate).IsRequired();
        modelBuilder.Entity<EventPerformerEntity>().Property(p => p.Name).IsRequired().HasMaxLength(200);

        modelBuilder.Entity<EventOrganizerEntity>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<EventOrganizerEntity>().HasMany(p=>p.Events).WithOne(o=>o.Organizer).HasForeignKey(o=>o.OrganizerId);
    }
}
