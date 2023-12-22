using Microsoft.EntityFrameworkCore;
using Simple_API.Models;

namespace Simple_API.Data
{
    public class TaskDataController : DbContext
    {
        public TaskDataController(DbContextOptions<TaskDataController> options)
        : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
