using Microsoft.EntityFrameworkCore;
namespace Server.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; } = null!;
    }
 }