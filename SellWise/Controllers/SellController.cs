using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellWise.Core.Contracts;
using SellWise.Core.Models.SaleModel;
using System.Security.Claims;

namespace SellWise.Controllers
{
    [Authorize]
    public class SellController : Controller
    {
        private readonly ISellService sellService;

        public SellController(ISellService sellService)
        {
            this.sellService = sellService;
        }

        [HttpGet]
        public async Task<IActionResult> SellSystem()
        {
            string userId = User.Id();

            IEnumerable<SaleViewModel> sales = await this.sellService.MySales(userId);

            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSale()
        {
            string userId = User.Id();
            await this.sellService.CreateSale(userId);

            return RedirectToAction(nameof(SellSystem));
        }
    }
}
