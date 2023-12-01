using AD_Asignment_GroupD_T2207E.Data;
using AD_Asignment_GroupD_T2207E.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AD_Asignment_GroupD_T2207E.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var emailExist = await _userManager.FindByEmailAsync(registerModel.Email);
                if (emailExist != null)
                {
                    return Ok("Exists");
                }
                var user = new AppUser
                {
                    UserName = registerModel.Email,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    return Ok("success");
                }
                {
                    return NotFound();
                }
            }
            return Ok("Input Failed");
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }

        //Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View();
        }
    }
}
