using Microsoft.EntityFrameworkCore;
using JobSearchApplication.Models;

namespace JobSearchApplication.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
       

    }
}
