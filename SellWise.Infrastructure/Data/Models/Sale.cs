using Microsoft.EntityFrameworkCore;
using SellWise.Infrastructure.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellWise.Infrastructure.Data.Models
{
    public class Sale : IFinalize
    {
        public Sale()
        {
            this.SaleStartDateTime = DateTime.Now;
            this.IsFinalized = false;
            this.IsDiscountAplied = false;
            this.SaleProducts = new List<SaleProduct>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SaleStartDateTime { get; set; }

        [Required]
        public bool IsFinalized { get; set; }

        public DateTime? FinalizationDateTime { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }

        [Precision(18, 2)]
        public decimal? TotalPriceWithDiscount { get; set; }

        [Precision(18, 2)]
        public decimal? FinalPrice { get; set; }

        [Required]
        public bool IsDiscountAplied { get; set; }

        public int? DiscountPercentage { get; set; }

        //RELATIONS
        [Required]
        public string CashierId { get; set; } = null!;
        [ForeignKey(nameof(CashierId))]
        public Cashier Cashier { get; set; } = null!;


        [Required]
        public int ShiftId { get; set; }
        [ForeignKey(nameof(ShiftId))]
        public Shift Shift { get; set; }


        [InverseProperty(nameof(Sale))]
        public List<SaleProduct> SaleProducts { get; set; }
    }
}
