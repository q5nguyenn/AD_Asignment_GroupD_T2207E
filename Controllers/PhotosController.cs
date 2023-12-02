using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AD_Asignment_GroupD_T2207E.Data;
using AD_Asignment_GroupD_T2207E.Models;

namespace AD_Asignment_GroupD_T2207E.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Hàm search hình ảnh theo Tag
        public IActionResult Tag(string keyword)
        {
            var tags = _context.Tags.Where(t=>t.TagName.Contains(keyword)).Select(x => x.TagName).ToList();
            ViewData["Tags"] = tags;
            ViewData["Key"] = keyword;

			var photos = _context.Photos?
                    .Where(p => p.PhotoTags.Any(pt => pt.Tag.TagName.Contains(keyword)))
                    //.Include(x => x.User)
                    //.Include(x => x.Likes)
                    //Bao giờ có Model User với Likes rồi hiển thị cái này sau
                    .ToList();

            return View(photos);
        }


    }
}
