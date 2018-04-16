using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mealplan.Data;
using Mealplan.Models.CustomViewModels;

namespace Mealplan.Controllers
{
    public class BiodatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiodatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Biodatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Biodata.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Biodatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.Biodata
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.BioId == id);
            if (biodata == null)
            {
                return NotFound();
            }

            return View(biodata);
        }

        // GET: Biodatas/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id");
            return View();
        }

        // POST: Biodatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BioId,ActivityLevel,Birthday,Gender,Height,UserId,Weight")] Biodata biodata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biodata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id", biodata.UserId);
            return View(biodata);
        }

        // GET: Biodatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.Biodata.SingleOrDefaultAsync(m => m.BioId == id);
            if (biodata == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id", biodata.UserId);
            return View(biodata);
        }

        // POST: Biodatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BioId,ActivityLevel,Birthday,Gender,Height,UserId,Weight")] Biodata biodata)
        {
            if (id != biodata.BioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biodata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiodataExists(biodata.BioId))
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
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id", biodata.UserId);
            return View(biodata);
        }

        // GET: Biodatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.Biodata
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.BioId == id);
            if (biodata == null)
            {
                return NotFound();
            }

            return View(biodata);
        }

        // POST: Biodatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biodata = await _context.Biodata.SingleOrDefaultAsync(m => m.BioId == id);
            _context.Biodata.Remove(biodata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiodataExists(int id)
        {
            return _context.Biodata.Any(e => e.BioId == id);
        }
    }
}
