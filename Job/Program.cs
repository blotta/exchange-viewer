using Domain.Providers;
using Hangfire;
using Hangfire.SqlServer;
using Application.Services;
using Job.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(
        builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string not found")));
builder.Services.AddHangfireServer();

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddHostedService<ExchangeWorker>();

var host = builder.Build();
host.Run();
