using Microsoft.AspNetCore.Mvc;
using SellWise.Core.Contracts;
using SellWise.Core.Models.ProductModel;
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

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            IEnumerable<ProductViewModel> products = await this.saleService.ViewAllProducts();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> MySales()
        {
            string userId = User.Id();

            IEnumerable<SaleViewModel> sales = await this.saleService.MySales(userId);

            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSale()
        {
            string userId = User.Id();

            await this.saleService.CreateSale(userId);

            return RedirectToAction(nameof(MySales));
        }

        [HttpGet]
        public async Task<ActionResult> Sale(int saleId)
        {
            var userId = User.Id();

            SaleViewModel sale = await this.saleService.GetSale(saleId);

            return View(sale);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSale(int saleId)
        {
            var userId = User.Id();

            await this.saleService.DeleteSale(saleId, userId);
            return RedirectToAction(nameof(MySales));
        }
    }
}
