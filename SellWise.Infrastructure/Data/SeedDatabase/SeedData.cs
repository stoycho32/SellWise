using Microsoft.AspNetCore.Identity;
using SellWise.Data;
using SellWise.Infrastructure.Data.Models;

namespace SellWise.Infrastructure.Data.SeedDatabase
{
    public class SeedData
    {
        public Product Product1 { get; set; }
        public Product Product2 { get; set; }
        public Product Product3 { get; set; }
        public Product Product4 { get; set; }
        public Product Product5 { get; set; }
        public Cashier AdminUser { get; set; }


        public SeedData()
        {
            this.SeedProducts();
            this.SeedAdmin();
        }

        public void SeedProducts()
        {
            Product1 = new Product()
            {
                Id = 1,
                ProductName = "Davidoff Gold",
                ProductQuantity = 10,
                ProductDeliveryPrice = 6.15m,
                ProductSellingPrice = 6.20m,
            };

            Product2 = new Product()
            {
                Id = 2,
                ProductName = "Karelia blue 100",
                ProductQuantity = 10,
                ProductDeliveryPrice = 5.40m,
                ProductSellingPrice = 5.50m,
            };

            Product3 = new Product()
            {
                Id = 3,
                ProductName = "Rothmans DarkBlue 100",
                ProductQuantity = 10,
                ProductDeliveryPrice = 5.10m,
                ProductSellingPrice = 5.20m,
            };

            Product4 = new Product()
            {
                Id = 4,
                ProductName = "Coca-Cola",
                ProductQuantity = 24,
                ProductDeliveryPrice = 1.15m,
                ProductSellingPrice = 2.20m,
            };

            Product5 = new Product()
            {
                Id = 5,
                ProductName = "Chio-Chips Paprika",
                ProductQuantity = 6,
                ProductDeliveryPrice = 2.10m,
                ProductSellingPrice = 3.20m,
            };
        }

        public void SeedAdmin()
        {
            var hasher = new PasswordHasher<Cashier>();

            this.AdminUser = new Cashier()
            {
                Id = "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                FirstName = "Stoycho",
                LastName = "Karadaliev"
            };

            this.AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Admin123!");
        }
    }
}
