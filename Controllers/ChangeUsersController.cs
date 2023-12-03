using AD_Asignment_GroupD_T2207E.Data;
using AD_Asignment_GroupD_T2207E.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AD_Asignment_GroupD_T2207E.Controllers
{
	public class ChangeUsersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ChangeUsersController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> ChangeUser()
		{
			var userManager = HttpContext.RequestServices.GetService<UserManager<AppUser>>();

			var user = await userManager.GetUserAsync(User);
			if (user == null)
			{
				return Ok("Chưa đăng nhập");
			}
			else
			{
				return View();
			}
			
		}

		[HttpPost]
		public async Task<IActionResult> ChangeUser(AppUser appUser)
		{
			var userManager = HttpContext.RequestServices.GetService<UserManager<AppUser>>();

			var user = await userManager.GetUserAsync(User);
			if (user == null)
			{
				return Ok("Chưa đăng nhập");
			}
			try
			{
				var userFind = await _context.AspNetUsers.FindAsync(user.Id);
				if (userFind.FirstName != appUser.FirstName)
					userFind.FirstName = appUser.FirstName;
				if (userFind.LastName != appUser.LastName)
					userFind.LastName = appUser.LastName;
				if (userFind.Email != appUser.Email)
					userFind.Email = appUser.Email;
				if (userFind.UserName != appUser.UserName)
					userFind.UserName = appUser.UserName;
				_context.Update(userFind);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}

			return RedirectToAction(nameof(ChangeUser));

		}
	}
}
