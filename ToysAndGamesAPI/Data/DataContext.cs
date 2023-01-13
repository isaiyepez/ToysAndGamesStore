using Microsoft.EntityFrameworkCore;
using ToysAndGamesAPI.Entities;

namespace ToysAndGamesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed products
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Monopoly",
                Description = "Popular Board Game",
                AgeRestriction = 0,
                Company = "Mattel",
                Price = 70
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Iron Man Action Figure",
                Description = "Action Figure with sounds and light",
                AgeRestriction = 5,
                Company = "Mattel",
                Price = 80
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Monster High doll",
                Description = "Beautiful and creepy doll at once",
                AgeRestriction = 8,
                Company = "Mattel",
                Price = 30
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Batmobile",
                Description = "Dark Knight's most famous gadget!",
                AgeRestriction = 5,
                Company = "Hasbro",
                Price = 180
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Playstation 5",
                Description = "Sony famous console",
                AgeRestriction = 4,
                Company = "Sony",
                Price = 400
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "The last of Us 2",
                Description = "Great Videogame from Naughty Dog!",
                AgeRestriction = 18,
                Company = "Naughty Dog",
                Price = 60
            });
        }
    }
}
