using Microsoft.EntityFrameworkCore;
using TodoProject.Models;

namespace TodoProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskMaster> Tasks { get; set; }
    }
}
