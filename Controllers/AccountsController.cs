using AD_Asignment_GroupD_T2207E.Data;
using AD_Asignment_GroupD_T2207E.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AD_Asignment_GroupD_T2207E.Controllers
{
	public class AccountsController : Controller
	{

		private readonly ApplicationDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager; 

        public AccountsController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;  
        }

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}
	}
}
