using Microsoft.EntityFrameworkCore;
using SecondDbProject.Entities; // Updated namespace

namespace SecondDbProject.Context
{
    public class MySecondDbContext : DbContext
    {
        public MySecondDbContext(DbContextOptions<MySecondDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
