using Microsoft.EntityFrameworkCore;
using SellWise.Infrastructure.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellWise.Infrastructure.Data.Models
{
    public class Product : IDeletable
    {
        public Product()
        {
            this.IsDeleted = false;
            this.SaleProducts = new List<SaleProduct>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Product Name Must Be Between 2 and 30 characters")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(1, 50000)]
        public int ProductQuantity { get; set; }

        [Required]
        [Precision(18,2)]
        [Range(0.01, 15000)]
        public decimal ProductPrice { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = "Product Comment Cannot Be Empty. It must be between 3 and 250 characters")]
        public string? ProductComment { get; set; }

        [Required]
        public bool IsDeleted { get; set; }



        //RELATIONS
        [Required]
        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; }


        [InverseProperty(nameof(Product))]
        public List<SaleProduct> SaleProducts { get; set; }
    }
}
