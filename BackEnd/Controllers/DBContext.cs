using Microsoft.EntityFrameworkCore;
namespace Server.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        // public DbSet<MyModel> MyModels { get; set; } = null!;
    }
 }