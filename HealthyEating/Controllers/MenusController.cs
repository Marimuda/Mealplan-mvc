using HealthyEating.Data;
using HealthyEating.Models;
using HealthyEating.Models.MealViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEating.Controllers
{
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Menus

        public async Task<IActionResult> Index(int? id, int? recipeID)
        {
            var viewModel = new MenuIndexData
            {
                Menus = await _context.Menus
                .Include(i => i.MenuChoices)
                .ThenInclude(i => i.Recipes)
                .ThenInclude(i => i.RecipeIngredients)
                .ThenInclude(i => i.Ingredients)
                .Include(i => i.MenuChoices)
                .ThenInclude(i => i.RecipeType)
                .Include(i => i.Users)
                .ThenInclude(i => i.BioDatas)
                .OrderByDescending(i => i.MealPlan)
                .ToListAsync()
            };

            /* Public Access to Personal Metabolism */
            if (User.Identity.GetUserId() != null)
            {
                viewModel.BioDatas = await _context.BioDatas.ToListAsync();
                ViewData["Metabolism"] = viewModel.BioDatas.Where(i => i.UserID == User.Identity.GetUserId()).Select(j => j.AMR).FirstOrDefault();
            }


            /* Assign default menu if not specified otherwise */
            if (id == null)
            {
                var tempID = viewModel.Menus.Where(i => i.MealPlan.Value == Menu.MealPlans.True).Select(i => i.MenuID).FirstOrDefault();
                id = tempID;
                ViewData["MenuID"] = id.Value;
                Menu menu = viewModel.Menus.Single(i => i.MenuID == id.Value);
                viewModel.Recipes = menu.MenuChoices.Select(s => s.Recipes);
            }
            else
            {
                ViewData["MenuID"] = id.Value;
                Menu menu = viewModel.Menus.Single(i => i.MenuID == id.Value);
                viewModel.Recipes = menu.MenuChoices.Select(s => s.Recipes);
            }

            /* Gather Ingredient data for a given recipe*/
            if (recipeID != null)
            {
                ViewData["RecipeID"] = recipeID.Value;
                var SelectedRecipe = viewModel.Recipes.Where(x => x.RecipeID == recipeID).FirstOrDefault();
                await _context.Entry(SelectedRecipe).Collection(x => x.RecipeIngredients).LoadAsync();
                foreach (RecipeIngredient RecipeIngredient in SelectedRecipe.RecipeIngredients)
                {
                    await _context.Entry(RecipeIngredient).Reference(x => x.Ingredients).LoadAsync();
                }
                viewModel.RecipeIngredients = SelectedRecipe.RecipeIngredients;

            }

            return View(viewModel);
            //Add Biodata link to ingredients for math operations.
            //Figure Out the ratios, different kinds, one kind, source?

        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Users)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MenuID == id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            var menu = new Menu();
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            menu.MenuChoices = new List<MenuChoice>();

            PopulateAssignedRecipeData(_context, menu);
            PopulateAssignedRecipeType(_context, menu);
            return View();
        }

        // POST: Menus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuID,MenuName,MealPlan,UsersId")] Menu menu, string[] selectedRecipes, string[] selectedType)
        {
            if (selectedRecipes != null)
            {
                int j = 0;
                menu.MenuChoices = new List<MenuChoice>();
                foreach (var recipe in selectedRecipes)
                {

                    var RecipeToAdd = new MenuChoice { MenuID = menu.MenuID, RecipeID = int.Parse(recipe), RecipeTypeID = int.Parse(selectedType[j]) };
                    menu.MenuChoices.Add(RecipeToAdd);
                    j++;
                }
            }
            if (ModelState.IsValid)
            {
                if (User.IsInRole("User") == true)
                {
                    string LoggedInUser = User.Identity.GetUserId();
                    menu.UsersId = LoggedInUser;
                    menu.MealPlan = Menu.MealPlans.False;
                }
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "FirstName", menu.UsersId);
            PopulateAssignedRecipeData(_context, menu);
            PopulateAssignedRecipeType(_context, menu);
            return View(menu);
        }



        // GET: Menus/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(i => i.MenuChoices).ThenInclude(i => i.Recipes)
                .AsNoTracking()
                .SingleOrDefaultAsync(r => r.MenuID == id);

            if (menu == null)
            {
                return NotFound();
            }

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");

            if (ViewData["UserID"] == null)
            {
                return NotFound();
            }

            PopulateAssignedRecipeData(_context, menu);

            return View(menu);
        }

        private void PopulateAssignedRecipeData(ApplicationDbContext context, Menu menu)
        {
            var AllRecipes = _context.Recipes;
            var MenuChoice = new HashSet<int>(menu.MenuChoices.Select(r => r.RecipeID));
            var viewModel = new List<AssignedRecipes>();
            foreach (var recipe in AllRecipes)
            {
                viewModel.Add(new AssignedRecipes
                {
                    RecipeID = recipe.RecipeID,
                    RecipeName = recipe.RecipeName,
                    Assigned = MenuChoice.Contains(recipe.RecipeID)
                });
            }
            ViewData["Recipes"] = viewModel;
        }


        private void PopulateAssignedRecipeType(ApplicationDbContext context, Menu menu)
        {
            var AllRecipeTypes = _context.RecipeTypes;
            var MenuChoice = new HashSet<int>(menu.MenuChoices.Select(r => r.RecipeID));
            var viewModel = new List<AssignedType>();
            foreach (var type in AllRecipeTypes)
            {
                viewModel.Add(new AssignedType
                {
                    TypeID = type.ID,
                    TypeName = type.CourseType,
                    Assigned = MenuChoice.Contains(type.ID)
                });
            }
            ViewData["RecipeTypes"] = viewModel;
        }

        // POST: Menus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedRecipes, Menu menu)
        {
            if (id != menu.MenuID)
            {
                return NotFound();
            }

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");

            var menuToUpdate = await _context.Menus
            .Include(i => i.MenuChoices)
            .ThenInclude(i => i.Recipes)
            .SingleOrDefaultAsync(m => m.MenuID == id);


            if (await TryUpdateModelAsync<Menu>(menuToUpdate,
                "",
                i => i.MenuName, i => i.MealPlan, i => i.UsersId))
            {
                UpdateRecipesInMenu(_context, selectedRecipes, menuToUpdate);
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

            UpdateRecipesInMenu(_context, selectedRecipes, menuToUpdate);
            PopulateAssignedRecipeData(_context, menuToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void UpdateRecipesInMenu(ApplicationDbContext context, string[] SelectedRecipes, Menu menuToUpdate)
        {
            if (SelectedRecipes == null)
            {
                menuToUpdate.MenuChoices = new List<MenuChoice>();
                return;
            }

            var selectedRecipesHS = new HashSet<string>(SelectedRecipes);
            var MenuRecipe = new HashSet<int>
                (menuToUpdate.MenuChoices.Select(c => c.Recipes.RecipeID));
            foreach (var recipe in context.Recipes)
            {
                if (selectedRecipesHS.Contains(recipe.RecipeID.ToString()))
                {
                    if (!MenuRecipe.Contains(recipe.RecipeID))
                    {
                        menuToUpdate.MenuChoices.Add(new MenuChoice { MenuID = menuToUpdate.MenuID, RecipeID = recipe.RecipeID });
                    }
                }
                else
                {
                    if (MenuRecipe.Contains(recipe.RecipeID))
                    {
                        MenuChoice RecipeToRemove = menuToUpdate.MenuChoices.SingleOrDefault(i => i.RecipeID == recipe.RecipeID);
                        _context.Remove(RecipeToRemove);
                    }
                }
            }
        }


        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Users)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MenuID == id);

            if (menu == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, bool? saveChangesError = false)
        {
            Menu menu = await _context.Menus
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MenuID == id);


            if (menu == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuID == id);
        }
    }
}
