using EShopApp.Models;

namespace EShopApp.Services
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Adventurer GPS Watch", Price = 199.99m, ImageUrl = "/images/gps-watch.png", Brand = "AirStrider", Type = "Navigation" },
                new Product { Id = 2, Name = "AeroLite Cycling Helmet", Price = 129.99m, ImageUrl = "/images/helmet.png", Brand = "AirStrider", Type = "Cycling" },
                new Product { Id = 3, Name = "Alpine AlpinePack Backpack", Price = 129.00m, ImageUrl = "/images/backpack.png", Brand = "Gravitator", Type = "Bags" },
                new Product { Id = 4, Name = "Alpine Fusion Goggles", Price = 79.99m, ImageUrl = "/images/goggles.png", Brand = "Alpine", Type = "Ski boarding" },
                new Product { Id = 5, Name = "Alpine Peak Down Jacket", Price = 249.99m, ImageUrl = "/images/jacket.png", Brand = "Alpine", Type = "Jackets" },
                new Product { Id = 6, Name = "Alpine Tech Crampons", Price = 149.00m, ImageUrl = "/images/crampons.png", Brand = "Alpine", Type = "Climbing" }
            };
        }

        public List<string> GetBrands()
        {
            return new List<string> { "All", "AirStrider", "B&R", "Daybird", "Gravitator", "Green Equipment", "Grolltex", "Legend", "Quester", "Raptor Elite", "Soltrix", "WildRunner", "XE", "Zephyr" };
        }

        public List<string> GetTypes()
        {
            return new List<string> { "All", "Bags", "Climbing", "Cycling", "Footwear", "Jackets", "Navigation", "Ski boarding", "Trekking" };
        }
    }
}