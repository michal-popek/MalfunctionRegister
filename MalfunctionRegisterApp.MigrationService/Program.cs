using DatabaseMigrations.MigrationService;
using MalfunctionRegisterApp.ApiModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<ApiDbInitializer>();

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("malfunctionregisterdatabase"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("MalfunctionRegisterApp.MigrationService");
        // Workaround for https://github.com/dotnet/aspire/issues/1023
        sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
    }));
builder.EnrichSqlServerDbContext<ApplicationDbContext>(settings =>
    // Disable Aspire default retries as we're using a custom execution strategy
    settings.DisableRetry = true);

var app = builder.Build();

app.Run();