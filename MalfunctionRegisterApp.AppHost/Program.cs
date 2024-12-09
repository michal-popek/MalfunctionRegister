var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("malfunctionregisterserver").AddDatabase("MalfunctionRegisterDatabase");

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.MalfunctionRegisterApp_ApiService>("apiservice")
    .WithReference(sql).
    WaitFor(sql);

builder.AddProject<Projects.MalfunctionRegisterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
