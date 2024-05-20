using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SellWise.Core.Models.ProductModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Product Name Must Be Between 2 and 30 characters")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(1, 50000)]
        public int ProductQuantity { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(0.01, 15000)]
        public decimal ProductSellingPrice { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Manufacturer Name Must Be Between 3 and 50 Characters Long")]
        public string ManufacturerName { get; set; } = null!;
    }
}
