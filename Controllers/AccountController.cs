using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using eCommerceApp.Entities;
using eCommerceApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<AppRoles> _roleManager;
        private readonly SignInManager<Customer> _signInManager;

        public AccountController(UserManager<Customer> userManager,
                            RoleManager<AppRoles> roleManager,
                            SignInManager<Customer> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region RegisterSettings



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(customer, model.Password);

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("SiteUser").Result)
                    {
                        AppRoles role = new AppRoles();
                        role.Name = "SiteUser";

                        IdentityResult roleManager = _roleManager.CreateAsync(role).Result;

                        if (!roleManager.Succeeded)
                        {
                            ModelState.AddModelError("", "Something goes wrong!");
                            return View(model);
                        }
                    }

                    _userManager.AddToRoleAsync(customer, "SiteUser").Wait();
                    await _signInManager.SignInAsync(customer, false);
                    return RedirectToAction("Login", "Account");
                }

            }
            return View(model);
        }

        #endregion

        #region LoginSettings

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    false
                    );
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Something goes wrong!");
                }

            }
            return View(model);
        }

        #endregion

        #region Logout
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

    }
}
