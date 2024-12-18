using Microsoft.EntityFrameworkCore;

namespace MalfunctionRegisterApp.ApiModel;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<MalfunctionReport> Reports { get; set; }
}
