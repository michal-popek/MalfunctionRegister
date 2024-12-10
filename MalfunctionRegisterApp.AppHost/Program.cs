var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddAzureSqlServer("malfunctionregisterserver"); 
var database = sql.AddDatabase("MalfunctionRegisterDatabase");

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.MalfunctionRegisterApp_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WithReference(sql).
    WaitFor(database);

builder.AddProject<Projects.MalfunctionRegisterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
