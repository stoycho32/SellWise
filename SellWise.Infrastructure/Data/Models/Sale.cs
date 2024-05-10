using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellWise.Infrastructure.Data.Models
{
    public class Sale
    {
        public Sale()
        {
            this.SaleProducts = new List<SaleProduct>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SaleDateTime { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }



        //RELATIONS
        [Required]
        public string CashierId { get; set; } = null!;
        [ForeignKey(nameof(CashierId))]
        public Cashier Cashier { get; set; } = null!;

        [InverseProperty(nameof(Sale))]
        public List<SaleProduct> SaleProducts { get; set; }
    }
}
