using Aspire.Hosting.Dapr;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("malfunctionregisterserver"); 
var dataBase = sql.AddDatabase("malfunctionregisterdatabase");

var migrationServive = builder.AddProject<Projects.MalfunctionRegisterApp_MigrationService>("migrationservice").
    WithReference(dataBase).
    WaitFor(dataBase);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.MalfunctionRegisterApp_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WithReference(dataBase).
    WaitForCompletion(migrationServive).
    WithDaprSidecar("apiserviceSidecar");

builder.AddProject<Projects.MalfunctionRegisterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService).
    WaitFor(apiService).
    WithDaprSidecar("webfrontendSidecar");

if (builder.Configuration.GetValue<string>("DAPR_CLI_PATH") is { } daprCliPath)
{
    builder.Services.Configure<DaprOptions>(options =>
    {
        options.DaprPath = daprCliPath;
    });
}

builder.Build().Run();
