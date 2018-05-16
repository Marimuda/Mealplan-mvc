using HealthyEating.Data;
using HealthyEating.Models;
using HealthyEating.Models.MealViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEating.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;


        public RecipesController(ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;

        }

        // GET: Recipes
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page, int? id)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CreationSortParm"] = sortOrder == "ID" ? "ID_desc" : "ID";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var Recipes = from u in _context.Recipes
            .Include(u => u.RecipeRatings)
            .Include(u => u.Users)
                          select u;

            if (id != null)
            {
                ViewData["RecipeID"] = id.Value;
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                Recipes = Recipes.Where(s => s.RecipeDescription.Contains(searchString)
                                       || s.RecipeName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Recipes = Recipes.OrderByDescending(s => s.RecipeName);
                    break;
                case "ID":
                    Recipes = Recipes.OrderBy(s => s.UsersId);
                    break;
                case "ID_desc":
                    Recipes = Recipes.OrderByDescending(s => s.UsersId);
                    break;
                default:
                    Recipes = Recipes.OrderBy(s => s.RecipeName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Recipe>.CreateAsync(Recipes, page ?? 1, pageSize));
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Users)
                .Include(i => i.RecipeIngredients)
                .ThenInclude(m => m.Ingredients)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.RecipeID == id);

            recipe.RecipeRatings = _context.RecipeRatings.Where(d => d.RecipeID.Equals(id.Value)).ToList();
            if (recipe.RecipeRatings.Count() > 0)
            {

                int p = 0;
                int m = 0;

                foreach (var item in recipe.RecipeRatings)
                {
                    if (item.Score > 0)
                    {
                        p++;
                    }
                    else
                    {
                        m++;
                    }
                }

                var ratingSum = recipe.RecipeRatings.Sum(d => d.Score);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = recipe.RecipeRatings.Count();
                ViewBag.RatingCount = ratingCount;
                ViewBag.RatingCountP = p;
                ViewBag.RatingCountM = m;

            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
                ViewBag.RatingCountP = 0;
                ViewBag.RatingCountM = 0;
            }

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            var Recipes = new Recipe();
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");

            Recipes.RecipeIngredients = new List<RecipeIngredient>();

            PopulateAssignedIngredientData(_context, Recipes);

            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeName,RecipeDescription,RecipeImage,RecipeRatning,RecipeCreationTime,UserID")] Recipe recipe, IFormFile picture, string[] selectedIngredients)
        {
            if (selectedIngredients != null)
            {
                recipe.RecipeIngredients = new List<RecipeIngredient>();
                foreach (var ingredient in selectedIngredients)
                {
                    var IngredientToAdd = new RecipeIngredient { RecipeID = recipe.RecipeID, IngredientID = int.Parse(ingredient), Amount = 100 };
                    recipe.RecipeIngredients.Add(IngredientToAdd);
                }
            }
            var k = "";
            try
            {
                if (picture != null)
                {
                    if (Path.GetFileName(picture.FileName) != null)
                    {
                        k = Path.GetFileName(picture.FileName);
                    }


                    var filename = Path.Combine(he.WebRootPath, k);
                    picture.CopyTo(new FileStream(filename, FileMode.Create));

                    ViewData["fileLocation"] = "/" + k;

                }
                if (ModelState.IsValid)
                {
                    recipe.RecipeImage = ViewData["fileLocation"].ToString();

                    if (User.IsInRole("User") == true)
                    {
                        string LoggedInUser = User.Identity.GetUserId();
                        recipe.UsersId = LoggedInUser;

                    }
                    _context.Add(recipe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }

            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            //ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", recipe.UsersId);
            PopulateAssignedIngredientData(_context, recipe);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(i => i.RecipeIngredients)
                .ThenInclude(i => i.Ingredients)
                .AsNoTracking()
                .SingleOrDefaultAsync(r => r.RecipeID == id);

            //var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeID == id);

            if (recipe == null)
            {
                return NotFound();
            }

            // var TimeQuery = from d in _context.Recipes.Where(t => t.RecipeID == id)
            //                 orderby d.RecipeID
            //                 select d;
            // ViewBag.CreationTime = new SelectList(TimeQuery.AsNoTracking(), "RecipeID", "RecipeCreationTime", TimeQuery);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", recipe.UsersId);

            var temptime = recipe.RecipeCreationTime;


            if (ViewData["UserID"] == null)
            {
                return NotFound();
            }

            //UpdateIngredientsInRecipe(Ingredients, recipe);
            PopulateAssignedIngredientData(_context, recipe);
            return View(recipe);
        }

        private void PopulateAssignedIngredientData(ApplicationDbContext context, Recipe Recipe)
        {
            var AllIngredients = _context.Ingredients;
            var RecipeIngredients = new HashSet<int>(Recipe.RecipeIngredients.Select(r => r.IngredientID));
            var viewModel = new List<AssignedIngredients>();
            foreach (var Ingredient in AllIngredients)
            {
                viewModel.Add(new AssignedIngredients
                {
                    IngredientID = Ingredient.IngredientID,
                    IngredientName = Ingredient.IngredientName,
                    Assigned = RecipeIngredients.Contains(Ingredient.IngredientID)
                });
            }
            ViewData["Ingredients"] = viewModel;
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("RecipeID,RecipeName,RecipeDescription,RecipeImage,RecipeRatning,RecipeCreationTime,UsersId")]*/ string[] selectedIngredients, Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", recipe.UsersId);

            var RecipeToUpdate = await _context.Recipes
           .Include(i => i.RecipeIngredients)
           .ThenInclude(i => i.Ingredients)
           .SingleOrDefaultAsync(m => m.RecipeID == id);


            //var menuToUpdate = await _context.Menus.SingleOrDefaultAsync(m => m.MenuID == id);


            if (await TryUpdateModelAsync<Recipe>(RecipeToUpdate,
                "",
                i => i.RecipeName, i => i.RecipeDescription, i => i.RecipeImage, i => i.RecipeRatings, i => i.RecipeCreationTime, i => i.UsersId))
            {
                UpdateIngredientsInRecipe(_context, selectedIngredients, RecipeToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }

            // if (ModelState.IsValid)
            // {
            //     try
            //     {
            //         _context.Update(recipe);
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!RecipeExists(recipe.RecipeID))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }
            //     return RedirectToAction(nameof(Index));
            // }
            //


            UpdateIngredientsInRecipe(_context, selectedIngredients, RecipeToUpdate);
            PopulateAssignedIngredientData(_context, RecipeToUpdate);
            await _context.SaveChangesAsync();

            //return View(recipe);
            return RedirectToAction(nameof(Index));
        }


        private void UpdateIngredientsInRecipe(ApplicationDbContext context, string[] selectedIngredients, Recipe recipe)
        {
            if (selectedIngredients == null)
            {
                recipe.RecipeIngredients = new List<RecipeIngredient>();
                return;
            }


            var selectedingredientsHS = new HashSet<string>(selectedIngredients);
            var RecipeC = new HashSet<int>
                (recipe.RecipeIngredients.Select(c => c.Ingredients.IngredientID));
            foreach (var c in _context.Ingredients)
            {
                if (selectedingredientsHS.Contains(c.IngredientID.ToString()))
                {
                    if (!RecipeC.Contains(c.IngredientID))
                    {
                        recipe.RecipeIngredients.Add(new RecipeIngredient { RecipeID = recipe.RecipeID, IngredientID = c.IngredientID });
                    }
                }
                else
                {

                    if (RecipeC.Contains(c.IngredientID))
                    {
                        RecipeIngredient IngredientToRemove = recipe.RecipeIngredients.FirstOrDefault(i => i.IngredientID == c.IngredientID);
                        _context.Remove(IngredientToRemove);
                    }
                }
            }
        }


        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Users)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.RecipeID == id);

            if (recipe == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, bool? saveChangesError = false)
        {
            Recipe recipe = await _context.Recipes
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.RecipeID == id);

            if (recipe == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {

                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeID == id);
        }


        // //0..1 *
        // private void PopulateIngredientsDropDownList(object selectedIngredient = null)
        // {
        //     var ingredientQuery = from d in _context.Ingredients
        //                           orderby d.IngredientName
        //                           select d;
        //     ViewBag.IngredientID = new SelectList(ingredientQuery.AsNoTracking(), "IngredientID", "IngredientName", selectedIngredient);
        // }

        [HttpPost]
        public RecipeRating SetRating(int RecipeID, int Score)
        {


            RecipeRating rating = new RecipeRating();
            rating.Score = Convert.ToInt32(Score);
            rating.RecipeID = RecipeID;
            rating.UserID = User.Identity.GetUserId();

            _context.RecipeRatings.Add(rating);
            _context.SaveChanges();

            rating = _context.RecipeRatings
                .Include(x => x.Recipes)
                .Include(x => x.Recipes.RecipeRatings)
                .Include(x => x.Users)
                .SingleOrDefault(x => x.ID == rating.ID);

            return (rating);
            //return (i); //måske en fejl ved recipeid = id https://youtu.be/uSIlEY0gX9A?t=667
        }

        [HttpGet]
        public PartialViewResult RatingsControl(int RecipeID)
        {
            Recipe model = _context.Recipes.Find(RecipeID);

            return PartialView("_RatingsControl", model);
        }
    }
}
