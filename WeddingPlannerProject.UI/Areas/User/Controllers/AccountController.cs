using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Model;
using WeddingPlannerProject.Model.ViewModels;

namespace WeddingPlannerProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Lütfen tüm alanları doldurun." });
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Json(new { success = false, message = "Email veya şifre hatalı." });
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                model.Password,
                model.RememberMe,
                false);

            if (result.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return Json(new { success = true, redirectUrl = "/Admin/Home/Index" });
                }

                return Json(new { success = true, redirectUrl = "/User/Home/Index" });
            }

            return Json(new { success = false, message = "Email veya şifre hatalı." });
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            AppUser user = new AppUser
            {
                FullName = model.FullName,
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home", new { area = "User" });
            }

            var errors = string.Join(" ", result.Errors.Select(e => e.Description));
            TempData["RegisterError"] = "Kayıt işlemi başarısız oldu: " + errors;
            return RedirectToAction("Index", "Home", new { area = "User" });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "User" });
        }

    }
}