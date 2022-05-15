using CollectionSite.Data;
using CollectionSite.Data.Entities;
using CollectionSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet("sign-in")]
        public IActionResult SignIn() => View();

        [HttpGet("sign-up")]
        public IActionResult SignUp() => View();

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromForm] SignInViewModel model, [FromQuery] string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Users does not exist");
                return View(model);
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError(string.Empty, "Users is blocked");
                return View(model);
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, lockoutOnFailure: true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Password is incorrect");
                return View(model);
            }

            return RedirectToReturnUrlOrHome(returnUrl);
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromForm] SignUpViewModel model, [FromQuery] string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isEmailExist = _context.Users.Any(u => u.Email == model.Email);
            if (isEmailExist)
            {
                ModelState.AddModelError(string.Empty, "such an Email already exists");
                return View(model);
            }

            var user = new User
            {
                UserName = model.Name,
                Email = model.Email,
                IsActive = true,
            };

            var identityResult = await userManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var errorCode in identityResult.Errors.Select(e => e.Code))
                {
                    ModelState.AddModelError(string.Empty, errorCode);
                }

                return View(model);
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password,isPersistent: true, lockoutOnFailure: true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Password is incorrect");
                return View(model);
            }

            return RedirectToReturnUrlOrHome(returnUrl);
        }

        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOut([FromQuery] string? returnUrl)
        {
            await signInManager.SignOutAsync();
            return RedirectToReturnUrlOrHome(returnUrl);
        } 

        private IActionResult RedirectToReturnUrlOrHome(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        } 

        
    }
}
