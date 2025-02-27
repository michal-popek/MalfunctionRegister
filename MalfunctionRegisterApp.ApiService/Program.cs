using MalfunctionRegisterApp.ApiModel;
using MalfunctionRegisterApp.ApiService;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add service defaults & Aspire components.
        builder.AddServiceDefaults();

        //var connectionName = builder.Configuration.GetValue(typeof(string), "ConnectionStrings:malfunctionregisterserver") as string;
        //Console.WriteLine($"ConnectionName: {connectionName}");
        builder.AddSqlServerDbContext<ApplicationDbContext>("malfunctionregisterdatabase");
        builder.Services.AddAutoMapper(typeof(MappingConfig));
        builder.Services.AddControllers();

        // Add services to the container.
        builder.Services.AddProblemDetails();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //if (app.Environment.IsDevelopment())
        //{
        app.UseSwagger();
        app.UseSwaggerUI();
        //}

        // Configure the HTTP request pipeline.
        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            //using (var scope = app.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //    context.Database.EnsureCreated();
            //}
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days.
            // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


        app.MapDefaultEndpoints();
        app.MapControllers();

        app.Run();
    }
}