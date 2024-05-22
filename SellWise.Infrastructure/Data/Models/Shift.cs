using Microsoft.EntityFrameworkCore;
using SellWise.Infrastructure.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellWise.Infrastructure.Data.Models
{
    public class Shift : IFinalize
    {
        public Shift()
        {
            this.ShiftStartTime = DateTime.Now;
            this.IsFinalized = false;
            this.ShiftSales = new List<Sale>();
        }

        [Key]
        public int ShiftId { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal ShiftTotalAmount { get; set; }

        [Required]
        public DateTime ShiftStartTime { get; set; }

        [Required]
        public bool IsFinalized { get; set; }

        public DateTime? FinalizationDateTime { get; set; }

        //RELATIONS
        [InverseProperty(nameof(Shift))]
        public List<Sale> ShiftSales { get; set; }

        [Required]
        public string CashierId { get; set; } = null!;
        [ForeignKey(nameof(CashierId))]
        public Cashier Cashier { get; set; } = null!;
    }
}
