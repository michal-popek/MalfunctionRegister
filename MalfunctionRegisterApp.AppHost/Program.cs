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
    WaitFor(migrationServive);

builder.AddProject<Projects.MalfunctionRegisterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService).
    WaitFor(apiService);

builder.Build().Run();
