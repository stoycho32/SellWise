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
        public async Task<IActionResult> AllProducts(int saleId)
        {
            IEnumerable<ProductViewModel> products = await this.saleService.ViewAllProducts(saleId);

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

            SaleViewModel sale = await this.saleService.GetSale(saleId, userId);

            return View(sale);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSale(int saleId)
        {
            var userId = User.Id();

            await this.saleService.DeleteSale(saleId, userId);
            return RedirectToAction(nameof(MySales));
        }

        [HttpGet]
        public async Task<IActionResult> AddProductToSale(int saleId, int productId)
        {
            string userId = User.Id();

            await this.saleService.AddProductToSale(saleId, productId, userId);

            return RedirectToAction(nameof(Sale), new { saleId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductFromSale(int saleId, int productId)
        {
            string userId = User.Id();

            await this.saleService.RemoveProductFromSale(saleId, productId, userId);

            return RedirectToAction(nameof(Sale), new { saleId });
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseProductQuantity(int saleId, int productId)
        {
            string userId = User.Id();

            await this.saleService.IncreaseProductQuantity(saleId, productId, userId);

            return RedirectToAction(nameof(Sale), new { saleId });
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseProductQuantity(int saleId, int productId)
        {
            string userId = User.Id();

            await this.saleService.DecreaseProductQuantity(saleId, productId, userId);

            return RedirectToAction(nameof(Sale), new { saleId });
        }

        [HttpPost]
        public async Task<IActionResult> AddDiscountToSale(int saleId, int discountPercentage)
        {
            string userId = User.Id();

            await this.saleService.AddDiscount(saleId, discountPercentage, userId);

            return RedirectToAction(nameof(Sale), new { saleId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDiscountFromSale(int saleId)
        {
            string userId = User.Id();

            await this.saleService.RemoveDiscountFromSale(saleId, userId);

            return RedirectToAction(nameof(Sale), new { saleId });
        }

        [HttpPost]
        public async Task<IActionResult> FinalizeSale(int saleId)
        {
            string userId = User.Id();

            await this.saleService.FinalizeSale(saleId, userId);

            return RedirectToAction(nameof(MySales));
        }
    }
}
