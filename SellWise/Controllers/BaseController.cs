using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SellWise.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
