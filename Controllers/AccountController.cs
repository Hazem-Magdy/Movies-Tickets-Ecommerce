using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies_Tickets_Ecommerce_App.Data.Static;
using Movies_Tickets_Ecommerce_App.ViewModels;
using System.ComponentModel.DataAnnotations;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Movies_Tickets_Ecommerce_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            SignInManager = _signInManager;
            roleManager = _roleManager;
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
                    // add role to user
                    //await userManager.AddToRoleAsync(user, UserRoles.User);

                    // create cookie to user
                    await SignInManager.SignInAsync(user, false);

                    return RedirectToAction("RegisterCompleted");
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
        public IActionResult Login(/*string ReturnUrl = "~/Movies/Index"*/)
        {
            //ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser/*, string ReturnUrl="~/Movies/Index"*/)
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
                        //return LocalRedirect(ReturnUrl);
                    }
                    else
                    {

                        //ModelState.AddModelError("", "invalid username or password");
                        TempData["Error"] = "invalid username or password";

                    }
                }
                else
                {
                    //ModelState.AddModelError("", "in corect password or username");
                    TempData["Error"] = "invalid username or password";
                }

            }
            return View(loginUser);
        }

        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRole)
        {
            if (ModelState.IsValid == true)
            {

                IdentityRole role = new IdentityRole() { Name = newRole.RoleName };
                bool existRole = await roleManager.RoleExistsAsync(role.Name);
                if (existRole== false)
                {
                    IdentityResult result = await roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return View("AddRoleCompleted");
                    }
                }
                else
                {
                    TempData["Error"] = "Role Already Exist";
                    return View(newRole);
                }
            }
            return View();
        }

    }
}
