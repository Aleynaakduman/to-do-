using Microsoft.EntityFrameworkCore;

namespace todo
{
    public class ToDocontext : DbContext
    {
        public ToDocontext(DbContextOptions<ToDocontext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; } = null!;
        public DbSet< category> categories { get; set; } = null!;
        public DbSet<status> statuses { get; set; } = null!;

        // seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<category>().HasData(
                new category { categoryId = "work", Name = "work" },
                new category { categoryId = "home", Name = "Home" },
                new category { categoryId = "ex", Name = "Exercise" },
                new category { categoryId = "shop", Name = "Shopping" },
                new category { categoryId = "call", Name = "Contact" }
                );
            modelBuilder.Entity<status>().HasData(
                new status { statusId = "open", Name = "open" },
                new status { statusId = "closed", Name = "completed" }
                );
        }
    }
}
