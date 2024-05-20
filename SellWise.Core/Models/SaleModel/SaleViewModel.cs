using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SellWise.Core.Models.SaleModel
{
    public class SaleViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime SaleStartDateTime { get; set; }

        [Required]
        public bool IsFinalized { get; set; }

        public DateTime? FinalizationDateTime { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }
    }
}
