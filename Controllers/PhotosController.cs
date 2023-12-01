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

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Photos.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Thumbnail,Camera,Views,Downloads,Likes,Description,Location,Extension,UserId")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", photo.UserId);
            return View(photo);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", photo.UserId);
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Thumbnail,Camera,Views,Downloads,Likes,Description,Location,Extension,UserId")] Photo photo)
        {
            if (id != photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", photo.UserId);
            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Photos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Photos'  is null.");
            }
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(string id)
        {
          return (_context.Photos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
