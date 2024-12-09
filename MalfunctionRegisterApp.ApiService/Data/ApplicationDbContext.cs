using Microsoft.EntityFrameworkCore;
using MalfunctionRegisterApp.ApiService.Models;

namespace MalfunctionRegisterApp.ApiService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MalfunctionReport> Reports { get; set; }
    }
}
