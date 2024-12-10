var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddAzureSqlServer("malfunctionregisterserver").AddDatabase("MalfunctionRegisterDatabase");

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.MalfunctionRegisterApp_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WithReference(sql).
    WaitFor(sql);

builder.AddProject<Projects.MalfunctionRegisterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
