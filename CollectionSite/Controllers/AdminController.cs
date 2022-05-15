using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectionSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [HttpGet("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
