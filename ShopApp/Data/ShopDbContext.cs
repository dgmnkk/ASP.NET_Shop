using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Configuration;
using ShopApp.Data.Entities;

namespace ShopApp.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Entities.Attribute> Attributes { get; set; }
        public ShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdvertConfig());
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Children`s world" },
                new Category { Id = 4, Name = "Real estate" },
                new Category { Id = 5, Name = "Auto" },
                new Category { Id = 6, Name = "Animals" },
                new Category { Id = 7, Name = "Hobby and sport" },
                new Category { Id = 8, Name = "House and garden" }
            );

            modelBuilder.Entity<Condition>().HasData(
                new Condition { Id = 1, Name = "New" },
                new Condition { Id = 2, Name = "Used" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "user1", Name = "Name1", Surname = "Surname1", Email = "email1@example.com" },
                new User { Id = 2, Login = "user2", Name = "Name2", Surname = "Surname2", Email = "email2@example.com" }
            );

            modelBuilder.Entity<Advertisement>().HasData(
                new Advertisement
                {
                    Id = 1,
                    Name = "IPhone 15",
                    Description = "Description",
                    Price = 800,
                    Brand = "Apple",
                    CategoryId = 1,
                    Views = 1000,
                    PublicationDate = new DateTime(2023, 1, 1),
                    ConditionId = 1,
                    SellerId = 1,
                    ImageUrl = "https://applecity.com.ua/image/cache/catalog/0iphone/ipohnex/iphone-x-black-1000x1000.png"
                },
                new Advertisement
                {
                    Id = 2,
                    Name = "MacBook Pro",
                    Description = "MacBook Pro 2019",
                    Price = 1200,
                    Brand = "Apple",
                    CategoryId = 1,
                    Views = 20,
                    PublicationDate = new DateTime(2023, 1, 2),
                    ConditionId = 2,
                    SellerId = 2,
                    ImageUrl = "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp"
                }
            );
        }

    }
}
