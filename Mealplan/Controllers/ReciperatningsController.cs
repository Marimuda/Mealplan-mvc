using Mealplan.Data;
using Mealplan.Models.CustomViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Mealplan.Controllers
{
    public class ReciperatningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReciperatningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reciperatnings
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Reciperatning.Include(r => r.Recipe);
            var reciperatnings = _context.Reciperatning
                .Include(c => c.Recipe)
                .AsNoTracking();
            return View(await reciperatnings.ToListAsync());
        }

        // GET: Reciperatnings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciperatning = await _context.Reciperatning
                .Include(r => r.Recipe)
                .SingleOrDefaultAsync(m => m.RecipeId == id);
            if (reciperatning == null)
            {
                return NotFound();
            }

            return View(reciperatning);
        }

        // GET: Reciperatnings/Create
        public IActionResult Create()
        {
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "RecipeId", "RecipeId");
            return View();
        }

        // POST: Reciperatnings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,RecipeRating")] Reciperatning reciperatning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reciperatning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "RecipeId", "RecipeId", reciperatning.RecipeId);
            return View(reciperatning);
        }

        // GET: Reciperatnings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciperatning = await _context.Reciperatning.SingleOrDefaultAsync(m => m.RecipeId == id);
            if (reciperatning == null)
            {
                return NotFound();
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "RecipeId", "RecipeId", reciperatning.RecipeId);
            return View(reciperatning);
        }

        // POST: Reciperatnings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,RecipeRating")] Reciperatning reciperatning)
        {
            if (id != reciperatning.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reciperatning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReciperatningExists(reciperatning.RecipeId))
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
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "RecipeId", "RecipeId", reciperatning.RecipeId);
            return View(reciperatning);
        }

        // GET: Reciperatnings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciperatning = await _context.Reciperatning
                .Include(r => r.Recipe)
                .SingleOrDefaultAsync(m => m.RecipeId == id);
            if (reciperatning == null)
            {
                return NotFound();
            }

            return View(reciperatning);
        }

        // POST: Reciperatnings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reciperatning = await _context.Reciperatning.SingleOrDefaultAsync(m => m.RecipeId == id);
            _context.Reciperatning.Remove(reciperatning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReciperatningExists(int id)
        {
            return _context.Reciperatning.Any(e => e.RecipeId == id);
        }
    }
}
