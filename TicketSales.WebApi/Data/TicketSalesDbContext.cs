using Aware.Data;
using Microsoft.EntityFrameworkCore;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Migrations;

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
        //modelBuilder.ApplyConfiguration(new CampaignConfigurations());

        //modelBuilder.Entity<Order>().HasKey("Order_Id_Os"); //Primary key
        //modelBuilder.Entity<Order>().HasKey(o => new { o.Order_ID, o.OwnerId }); //Composite primary key

        //modelBuilder.Entity<OrderItem>().ToTable("tbl_OrderItems");
        //modelBuilder.Entity<OrderItem>().HasKey(k => k.Order_Id);
        modelBuilder.Entity<EventEntity>().Property(p => p.Name).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<PlaceEntity>().Property(p => p.Name).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<EventPlaceEntity>().Property(p => p.StartDate).IsRequired();
        modelBuilder.Entity<EventPlaceEntity>().Property(p => p.EndDate).IsRequired();
        modelBuilder.Entity<EventPerformerEntity>().Property(p => p.Name).IsRequired().HasMaxLength(200);

        //modelBuilder.Entity<HutbeKonuEntity>().Property(p => p.Konu).IsRequired().HasMaxLength(300);
        //modelBuilder.Entity<HutbeKonuEntity>().HasMany(p => p.HutbeList).WithOne(p => p.HutbeKonu).HasForeignKey(p => p.HutbeKonuId);

        ////modelBuilder.Entity<OrderItem>().Property(p => p.UnitPrice).HasColumnName("Unit_Price");
        ////modelBuilder.Entity<OrderItem>().Ignore(p => p.Price); //NotMapped

        //modelBuilder.Entity<HutbeKonuHutbeEntity>().HasOne(p => p.Hutbe).WithMany().HasForeignKey(p => p.HutbeId);
        //modelBuilder.Entity<HutbeKonuHutbeEntity>().HasOne(p => p.HutbeKonu).WithMany(p=>p.HutbeList).HasForeignKey(p => p.HutbeKonuId);
    }

    public void Dispose()
    {

    }
}
