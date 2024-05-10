using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellWise.Infrastructure.Data.Models
{
    public class Shift
    {
        public Shift()
        {
            this.IsShiftFinished = false;
            this.ShiftStartTime = DateTime.Now;
            this.ShiftSales = new List<Sale>();
        }

        [Key]
        public int ShiftId { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal ShiftTotalAmount { get; set; }

        [Required]
        public bool IsShiftFinished { get; set; }

        [Required]
        public DateTime ShiftStartTime { get; set; }

        public DateTime? ShiftEndTime { get; set; }

        //RELATIONS
        [InverseProperty(nameof(Shift))]
        public List<Sale> ShiftSales { get; set; }

        [Required]
        public string CashierId { get; set; } = null!;
        [ForeignKey(nameof(CashierId))]
        public Cashier Cashier { get; set; } = null!;
    }
}
