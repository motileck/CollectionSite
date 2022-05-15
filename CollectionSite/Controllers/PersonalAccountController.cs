using System.Security.Claims;
using CollectionSite.Data;
using CollectionSite.Data.Entities;
using CollectionSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionSite.Controllers
{
    [Authorize]
    public class PersonalAccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext _context;

        public PersonalAccountController(UserManager<User> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet("personal-account")]
        public async Task<IActionResult> PersonalAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.First(u => u.Id.ToString() == userId);
            var roleName = (await userManager.GetRolesAsync(user)).SingleOrDefault();
            var model = new PersonalAccountViewModel()
            {
                Name = user.UserName,
                Role = roleName,
                Email = user.Email,
                Id = user.Id,

            };
            return View(model);
        }

        [HttpPost("personal-account")]
        public IActionResult PersonalAccount([FromForm]PersonalAccountViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.First(u => u.Id.ToString() == userId);
            user.Email = model.Email;
            user.UserName = model.Name;
            _context.SaveChanges();
            return RedirectToAction(controllerName:"PersonalAccount",actionName:"PersonalAccount");
        }
    }
}
