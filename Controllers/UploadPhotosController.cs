using AD_Asignment_GroupD_T2207E.Data;
using AD_Asignment_GroupD_T2207E.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AD_Asignment_GroupD_T2207E.Controllers
{
	public class UploadPhotosController : Controller
	{
		private readonly ApplicationDbContext _context;

		public UploadPhotosController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult UploadPhoto()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UploadPhoto(Photo photo, IFormFile FileImg, string TagName)
		{
			using (var memoryStream = new MemoryStream())
			{
				FileImg.CopyTo(memoryStream);
				var imgBytes = memoryStream.ToArray();
				var base64String = Convert.ToBase64String(imgBytes);
				photo.Thumbnail = base64String;
			}
			photo.Id = Guid.NewGuid().ToString();
			photo.Views = 0;
			photo.Likes = 0;
			photo.Downloads = 0;
			photo.Publish = DateTime.Now;
			photo.Camera = "No";
			string fileName = Path.GetFileName(FileImg.FileName);
			photo.Extension = Path.GetExtension(fileName);
			var userManager = HttpContext.RequestServices.GetService<UserManager<AppUser>>();

			var user = await userManager.GetUserAsync(User);

			if (user != null)
			{
				photo.UserId = user.Id;
			}
			else 
			{
				photo.UserId = "AUser";
			}

			var tag = new Tag();
			tag.Id = Guid.NewGuid().ToString();
			tag.TagName = TagName;
			tag.Searchs = 0;

			var photoTag = new PhotoTag();
			photoTag.PhotoId = photo.Id;
			photoTag.TagId = tag.Id;

			_context.Add(photo);
			_context.Add(tag);
			_context.Add(photoTag);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(UploadPhoto));

		}
	}
}
