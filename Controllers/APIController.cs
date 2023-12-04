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
    public class APIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public APIController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(string keyword)
        {
            var result = _context.Tags.Where(t => t.TagName.Contains(keyword)).ToList();
            return Ok(result);
        }

    }
}
