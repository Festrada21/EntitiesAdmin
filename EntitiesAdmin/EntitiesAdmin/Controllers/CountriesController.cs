using EntitiesAdmin.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiesAdmin.Controllers
{
    public class CountriesController : Controller
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Status = TempData["Status"];
            var dataContext = _context.Countries.Include(c => c.StatusField).Include(c => c.User).ThenInclude(u => u.Employee);
            return View(await dataContext.ToListAsync());
        }

     
        // GET: Countries/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                var statusfield = _context.StatusFields.FirstOrDefault(u => u.Name == "Active");

                country = new Country
                {
                    Name = country.Name,
                    EditionDate = date,
                    User = user,
                    StatusField = statusfield
                };

                try
                {
                    _context.Add(country);
                    await _context.SaveChangesAsync();
                    Messagebox("Created", "success");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        Messagebox($"Exist a record with {country.Name}, please check!", "error");
                    }
                    else
                    {
                        Messagebox(ex.Message, "error");
                    }

                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }

            return PartialView(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Messagebox("The record is null, please check!", "error");
                return RedirectToAction(nameof(Index));
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                Messagebox("The record don't exist, please check!", "error");
                return RedirectToAction(nameof(Index));
            }
        
            return PartialView(country);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Country country)
        {
            if (id != country.CountryId)
            {
                Messagebox("The record don't exist, please check!", "error");
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var date = DateTime.Now.ToUniversalTime();
                    var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    var statusfield = _context.StatusFields.FirstOrDefault(u => u.Name == "Active");

                    country.EditionDate = date;
                    country.User = user;
                    country.StatusField = statusfield;

                    _context.Update(country);
                    await _context.SaveChangesAsync();
                    Messagebox("Saved", "success");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!CountryExists(country.CountryId))
                    {
                        Messagebox(ex.Message, "error");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Messagebox("The field don't exist", "error");
                return RedirectToAction(nameof(Index));
            }

            var countries = await _context.Countries.Include(s => s.Site)
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (countries == null)
            {
                Messagebox("The field was previously deleted.", "error");
                return RedirectToAction(nameof(Index));
            }

            if (countries.Site.Count > 0)
            {
                Messagebox("Can't be removed. Please check dependencies", "error");
                return RedirectToAction(nameof(Index));
            }

            _context.Countries.Remove(countries);
            try
            {
                await _context.SaveChangesAsync();
                Messagebox("The field was deleted", "warning");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                Messagebox("Can't be removed.", "error");
                return RedirectToAction(nameof(Index));
            }

        }


        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }

        private void Messagebox(string message, string status)
        {
            TempData["Message"] = message;
            TempData["Status"] = status;
        }
    }
}
