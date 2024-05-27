using Microsoft.AspNetCore.Mvc;
using SellWise.Core.Contracts;
using SellWise.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SellWise.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShiftService shiftService;

        public HomeController(ILogger<HomeController> logger, IShiftService shiftService)
        {
            _logger = logger;
            this.shiftService = shiftService;
        }

        public IActionResult Home()
        {
            return View();
        }

        public async Task<IActionResult> StartShift()
        {
            string userId = User.Id();

            await this.shiftService.StartShift(userId);

            return RedirectToAction("MySales", "Sale");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}