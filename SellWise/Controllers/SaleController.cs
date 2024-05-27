using Microsoft.AspNetCore.Mvc;
using SellWise.Core.Contracts;
using SellWise.Core.Models.SaleModel;
using System.Security.Claims;

namespace SellWise.Controllers
{
    public class SaleController : BaseController
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        public async Task<IActionResult> MySales()
        {
            string userId = User.Id();

            IEnumerable<SaleViewModel> sales = await this.saleService.MySales(userId);

            return View(sales);
        }

        public async Task<IActionResult> CreateSale()
        {
            string userId = User.Id();

            await this.saleService.CreateSale(userId);

            return View("Sale");
        }

        public async Task<ActionResult> Sale(int id)
        {
            var userId = User.Id();

            SaleViewModel sale = await this.saleService.GetSale(id);

            return View(sale);
        }
    }
}
