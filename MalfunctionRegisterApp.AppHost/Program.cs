var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddAzureSqlServer("malfunctionregisterserver"); 
var dataBase = sql.AddDatabase("MalfunctionRegisterDatabase");

var migrationServive = builder.AddProject<Projects.MalfunctionRegisterApp_MigrationService>("malfunctionregisterapp-migrationservice").
    WithReference(dataBase).
    WaitFor(dataBase);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.MalfunctionRegisterApp_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WithReference(sql).
    WaitFor(migrationServive);

builder.AddProject<Projects.MalfunctionRegisterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);



builder.Build().Run();
