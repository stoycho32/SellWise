using Microsoft.AspNetCore.Mvc;
using SellWise.Core.Contracts;

namespace SellWise.Controllers
{
    public class SellController : Controller
    {
        private readonly ISellService productService;

        public SellController(ISellService productService)
        {
            this.productService = productService;
        }

        public IActionResult SellSystem()
        {
            return View();
        }
    }
}
