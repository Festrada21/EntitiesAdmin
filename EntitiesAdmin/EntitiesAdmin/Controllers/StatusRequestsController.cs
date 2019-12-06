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
    public class StatusRequestsController : Controller
    {
        private readonly DataContext _context;

        public StatusRequestsController(DataContext context)
        {
            _context = context;
        }

        // GET: StatusRequests
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.StatusRequest.Include(s => s.StatusField).Include(s => s.User);
            return View(await dataContext.ToListAsync());
        }

        // GET: StatusRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusRequest = await _context.StatusRequest
                .Include(s => s.StatusField)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StatusRequestId == id);
            if (statusRequest == null)
            {
                return NotFound();
            }

            return View(statusRequest);
        }

        // GET: StatusRequests/Create
        public IActionResult Create()
        {
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: StatusRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusRequestId,Name,StatusFieldId,UserId,EditionDate")] StatusRequest statusRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name", statusRequest.StatusFieldId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", statusRequest.UserId);
            return View(statusRequest);
        }

        // GET: StatusRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusRequest = await _context.StatusRequest.FindAsync(id);
            if (statusRequest == null)
            {
                return NotFound();
            }
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name", statusRequest.StatusFieldId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", statusRequest.UserId);
            return View(statusRequest);
        }

        // POST: StatusRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusRequestId,Name,StatusFieldId,UserId,EditionDate")] StatusRequest statusRequest)
        {
            if (id != statusRequest.StatusRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusRequestExists(statusRequest.StatusRequestId))
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
            ViewData["StatusFieldId"] = new SelectList(_context.StatusFields, "StatusFieldId", "Name", statusRequest.StatusFieldId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", statusRequest.UserId);
            return View(statusRequest);
        }

        // GET: StatusRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusRequest = await _context.StatusRequest
                .Include(s => s.StatusField)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StatusRequestId == id);
            if (statusRequest == null)
            {
                return NotFound();
            }

            return View(statusRequest);
        }

        // POST: StatusRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusRequest = await _context.StatusRequest.FindAsync(id);
            _context.StatusRequest.Remove(statusRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusRequestExists(int id)
        {
            return _context.StatusRequest.Any(e => e.StatusRequestId == id);
        }
    }
}
