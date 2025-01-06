using Aware.Data.EF;
using Microsoft.EntityFrameworkCore;
using TicketSales.WebApi.Data.Entity;

namespace TicketSales.WebApi.Data;

public class TicketSalesDbContext : AwareDbContext<TicketSalesDbContext>
{
    public TicketSalesDbContext(DbContextOptions<TicketSalesDbContext> options) : base(options)
    {
    }

    public DbSet<EventEntity> Event { get; set; }
    public DbSet<EventSessionEntity> EventSession { get; set; }
    public DbSet<PlaceEntity> Place { get; set; }
    public DbSet<PlaceHallEntity> PlaceHall { get; set; }
    public DbSet<PlaceHallSeatEntity> PlaceHallSeat { get; set; }
    public DbSet<EventTicketEntity> EventTicket { get; set; }
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
        modelBuilder.Entity<PlaceHallEntity>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<PlaceHallEntity>().HasOne(p => p.Place).WithMany().HasForeignKey(p => p.PlaceId);
        modelBuilder.Entity<EventSessionEntity>().Property(p => p.StartTime).IsRequired();
        modelBuilder.Entity<EventSessionEntity>().Property(p => p.Description).HasMaxLength(1000);
        modelBuilder.Entity<EventSessionEntity>().HasOne(p => p.Event).WithMany().HasForeignKey(p => p.EventId);
        modelBuilder.Entity<EventSessionEntity>().HasOne(p => p.PlaceHall).WithMany().HasForeignKey(p => p.PlaceHallId);
        modelBuilder.Entity<EventPerformerEntity>().Property(p => p.Name).IsRequired().HasMaxLength(200);

        modelBuilder.Entity<PlaceHallSeatEntity>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<PlaceHallSeatEntity>().HasOne(p => p.PlaceHall).WithMany().HasForeignKey(p => p.PlaceHallId);

        modelBuilder.Entity<EventTicketEntity>().Property(p => p.PurchaseTime).IsRequired();
        modelBuilder.Entity<EventTicketEntity>().HasOne(p => p.EventSession).WithMany().HasForeignKey(p => p.EventSessionId);
        modelBuilder.Entity<EventTicketEntity>().HasOne(p => p.HallSeat).WithMany().HasForeignKey(p => p.HallSeatId);
        modelBuilder.Entity<EventTicketEntity>().HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);

        modelBuilder.Entity<EventOrganizerEntity>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<EventOrganizerEntity>().HasMany(p => p.Events).WithOne(o => o.Organizer).HasForeignKey(o => o.OrganizerId);
    }
}
