using SellWise.Data;
using SellWise.Infrastructure.Data.Models;

namespace SellWise.Infrastructure.Data.SeedDatabase
{
    public class SeedData
    {
       public Manufacturer Manufacturer1 { get; set; }
        public Manufacturer Manufacturer2 { get; set; }
        public Manufacturer Manufacturer3 { get; set; }
        public Manufacturer Manufacturer4 { get; set; }
        public Manufacturer Manufacturer5 { get; set; }
        public Product Product1 { get; set; }
        public Product Product2 { get; set; }
        public Product Product3 { get; set; }
        public Product Product4 { get; set; }
        public Product Product5 { get; set; }

        public SeedData()
        {
            this.SeedManufacturers();
            this.SeedProducts();
        }


        public void SeedManufacturers()
        {
            Manufacturer1 = new Manufacturer()
            {
                Id = 1,
                ManufacturerSerialNumber = 1234567890,
                ManufacturerName = "BGTabaco LTD",
                ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                ManufacturerEmail = "bgtabaco@abv.bg"
            };

            Manufacturer2 = new Manufacturer()
            {
                Id = 2,
                ManufacturerSerialNumber = 1234567890,
                ManufacturerName = "MarlboroBG LTD",
                ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                ManufacturerEmail = "marlborobg@abv.bg"
            };

            Manufacturer3 = new Manufacturer()
            {
                Id = 3,
                ManufacturerSerialNumber = 1234567890,
                ManufacturerName = "RothmansBG LTD",
                ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                ManufacturerEmail = "rothmansbg@abv.bg"
            };

            Manufacturer4 = new Manufacturer()
            {
                Id = 4,
                ManufacturerSerialNumber = 1234567890,
                ManufacturerName = "DrinksBG",
                ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                ManufacturerEmail = "drinksbg@abv.bg"
            };

            Manufacturer5 = new Manufacturer()
            {
                Id = 5,
                ManufacturerSerialNumber = 1234567890,
                ManufacturerName = "ChioBG LTD",
                ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                ManufacturerEmail = "chiochipsbg@abv.bg"
            };
        }

        public void SeedProducts()
        {
            Product1 = new Product()
            {
                Id = 1,
                ProductName = "Davidoff Gold",
                ProductQuantity = 10,
                ProductPrice = 6.20m,
                ManufacturerId = 1
            };

            Product2 = new Product()
            {
                Id = 2,
                ProductName = "Karelia blue 100",
                ProductQuantity = 10,
                ProductPrice = 5.50m,
                ManufacturerId = 3
            };

            Product3 = new Product()
            {
                Id = 3,
                ProductName = "Rothmans DarkBlue 100",
                ProductQuantity = 10,
                ProductPrice = 5.20m,
                ManufacturerId = 3
            };

            Product4 = new Product()
            {
                Id = 4,
                ProductName = "Coca-Cola",
                ProductQuantity = 24,
                ProductPrice = 2.20m,
                ManufacturerId = 4
            };

            Product5 = new Product()
            {
                Id = 5,
                ProductName = "Chio-Chips Paprika",
                ProductQuantity = 6,
                ProductPrice = 3.20m,
                ManufacturerId = 5
            };
        }
    }
}
