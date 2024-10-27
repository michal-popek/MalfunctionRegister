using MalfunctionRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace MalfunctionRegister.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<MalfunctionReport> Reports { get; set; }
    }
}
