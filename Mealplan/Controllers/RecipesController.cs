using Mealplan.Data;
using Mealplan.Models.CustomViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mealplan.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter,int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CreationSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            ViewData["CurrentFilter"] = searchString;


            var Recipes = from r in _context.Recipe                                            //
                          select r;                                                            //
            if (!String.IsNullOrEmpty(searchString))
            {
                Recipes = Recipes.Where(r => r.RecipeName.Contains(searchString)
                                       || r.RecipeDescription.Contains(searchString));
            }                                                                                 //var applicationDbContext = _context.Recipe.Include(r => r.User);                
                                                                                              //
            switch (sortOrder)                                                                 //
            {                                                                                  //
                case "name_desc":                                                              //
                    Recipes = Recipes.OrderByDescending(r => r.RecipeName);                    //
                    break;                                                                     //
                case "Date":                                                                   //
                    Recipes = Recipes.OrderBy(r => r.ReCreationDate);                          //
                    break;                                                                     //
                case "date_desc":                                                              //
                    Recipes = Recipes.OrderByDescending(r => r.ReCreationDate);                //
                    break;                                                                     //
                default:                                                                       //
                    Recipes = Recipes.OrderBy(r => r.RecipeName);                              //
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Recipe>.CreateAsync(Recipes.AsNoTracking(), page ?? 1, pageSize));
            //return View(await Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.User)
                .AsNoTracking() //
                .SingleOrDefaultAsync(m => m.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,ReCreationDate,RecipeDescription,RecipeName,UserId")] Recipe recipe)
        {
            try //
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recipe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException) //
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id", recipe.UserId);
            return View(recipe);

        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.SingleOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id", recipe.UserId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,ReCreationDate,RecipeDescription,RecipeName,UserId")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
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
            ViewData["UserId"] = new SelectList(_context.Aspnetusers, "Id", "Id", recipe.UserId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.User)
                .SingleOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.SingleOrDefaultAsync(m => m.RecipeId == id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeId == id);
        }
    }
}
