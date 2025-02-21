using Microsoft.EntityFrameworkCore;

namespace Mission6_Erickson.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
        {
        }

        public DbSet<Movie> Forms { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                
              new Category { CategoryID=1, CategoryName="Action"}, 
              new Category { CategoryID=2, CategoryName="Romantic Comedy"},
              new Category { CategoryID=3, CategoryName = "Horror" },
              new Category { CategoryID=4, CategoryName = "Drama" },
              new Category { CategoryID=5, CategoryName = "Television" },
              new Category { CategoryID=6, CategoryName = "Comedy" },
              new Category { CategoryID=7, CategoryName = "Family" },
              new Category { CategoryID=8, CategoryName = "Miscellaneous" }
            );
        }
    }
}
