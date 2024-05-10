using Microsoft.EntityFrameworkCore;
using SellWise.Infrastructure.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellWise.Infrastructure.Data.Models
{
    public class Manufacturer : IDeletable
    {
        public Manufacturer()
        {
            this.IsDeleted = false;
            this.Products = new List<Product>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Manufacturer EIK")]
        public int ManufacturerSerialNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Manufacturer Name Must Be Between 3 and 50 Characters Long")]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [StringLength(300, MinimumLength = 8, ErrorMessage = "Manufacturer Address Must Be Between 8 and 300 Characters Long")]
        public string ManufacturerAddress { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "The Manufacturer Email Is Not Valid")]
        public string ManufacturerEmail { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }


        //RELATIONS
        [InverseProperty(nameof(Manufacturer))]
        public List<Product> Products { get; set; }
    }
}
