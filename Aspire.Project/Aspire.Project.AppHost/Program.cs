var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Blazor_Web_UI>("blazor-web-ui");

builder.Build().Run();
