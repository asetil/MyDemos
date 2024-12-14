using TicketSales.WebApi.BusinessLogic.Dependency;
using Microsoft.EntityFrameworkCore;
using TicketSales.WebApi.Data;
using System.Reflection;
using Aware.Dependency;
using Aware.Util.Enum;
using Aware.Auth;
using Microsoft.OpenApi.Models;
using TicketSales.WebApi.BusinessLogic.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddOutputCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Ticket Sales Web API",
        Version = "v1"
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme,Id = "Bearer"}
            },
            new string[] {}
        }
    });
});

//Check Arrange method
var libraryInstaller = new LibraryInstaller();
libraryInstaller.Arrange(builder.Services, new DependencySetting()
{
    Assembly = Assembly.GetExecutingAssembly(),
    CacherType = CacherType.MemoryCache,
    UseAwareEntities = true,
}, builder.Configuration);

builder.Services.AddDbContext<TicketSalesDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TicketSales.WebApi"))
                .EnableSensitiveDataLogging() // Optional
                .LogTo(Console.WriteLine, LogLevel.Information)); // Logs to console;

var app = builder.Build();

//Seed Data
SeedData.Initialize(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<AwareJwtMiddleware>();
app.UseAuthorization();

app.MapControllers();
app.UseOutputCache();

app.Run();
