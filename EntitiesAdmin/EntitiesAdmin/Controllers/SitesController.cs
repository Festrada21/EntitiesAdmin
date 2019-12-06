using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntitiesAdmin.Data.Entities;

namespace EntitiesAdmin.Controllers
{
    public class SitesController : Controller
    {
        private readonly DataContext _context;

        public SitesController(DataContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Site.Include(s => s.Country).Include(s => s.StatusField).Include(s => s.User);
            return View(await dataContext.ToListAsync());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.Country)
                .Include(s => s.StatusField)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SiteId == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name");
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", site.CountryId);
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name", site.StatusFieldId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", site.UserId);
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", site.CountryId);
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name", site.StatusFieldId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", site.UserId);
            return View(site);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Site site)
        {
            if (id != site.SiteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.SiteId))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", site.CountryId);
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name", site.StatusFieldId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", site.UserId);
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.Country)
                .Include(s => s.StatusField)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SiteId == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Site.FindAsync(id);
            _context.Site.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.SiteId == id);
        }
    }
}
