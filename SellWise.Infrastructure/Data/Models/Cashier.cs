using Microsoft.AspNetCore.Identity;
using SellWise.Infrastructure.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellWise.Infrastructure.Data.Models
{
    public class Cashier : IdentityUser, IDisable
    {
        public Cashier()
        {
            this.IsDisabled = false;
            this.CashierSales = new List<Sale>();
            this.CashierShifts = new List<Shift>();
        }


        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Cashier First Name Must Be Between 2 and 100 Characters Long.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Cashier Last Name Must Be Between 2 and 100 Characters Long.")]
        public string LastName { get; set; } = null!;

        [Required]
        public bool IsDisabled { get; set;}




        //RELATIONS
        [InverseProperty(nameof(Cashier))]
        public List<Sale> CashierSales { get; set; }
        [InverseProperty(nameof(Cashier))]
        public List<Shift> CashierShifts { get; set; }
    }
}
