using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies_Tickets_Ecommerce_App.ViewModels;
using System.ComponentModel.DataAnnotations;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Movies_Tickets_Ecommerce_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> SignInManager;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            SignInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Registeration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterationViewModel newAccount)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = newAccount.UserName,
                    Email = newAccount.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false); // create cookie

                    return RedirectToAction("Index", "Movies");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(newAccount);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    SignInResult result = await SignInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                    else
                    {

                        ModelState.AddModelError("", "invalid username or password");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "in corect password or username");
                }

            }
            return View(loginUser);
        }

        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

    }
}
