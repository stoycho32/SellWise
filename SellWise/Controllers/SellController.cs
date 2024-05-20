using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellWise.Core.Contracts;

namespace SellWise.Controllers
{
    [Authorize]
    public class SellController : Controller
    {
        private readonly ISellService productService;

        public SellController(ISellService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult SellSystem()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MySales()
        {
            return View();
        }
    }
}
