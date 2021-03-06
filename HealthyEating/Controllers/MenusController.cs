﻿using HealthyEating.Data;
using HealthyEating.Models;
using HealthyEating.Models.MealViewModels;
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
                .Include(i => i.Users)
                .ThenInclude(i => i.BioDatas)
                .OrderByDescending(i => i.MealPlan)
                .ToListAsync()
            };

            if (id != null)
            {
                ViewData["MenuID"] = id.Value;
                Menu menu = viewModel.Menus.Single(i => i.MenuID == id.Value);
                viewModel.Recipes = menu.MenuChoices.Select(s => s.Recipes);
            }

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

                // Recipe recipe = viewModel.Recipes.Single(i => i.RecipeID == recipeID);
                // viewModel.Ingredients = viewModel.RecipeIngredients.Select(
                // x => x.Ingredients);
            }



            return View(viewModel);
            //Add Biodata link to ingredients for math operations.
            //Figure Out the ratios, different kinds, one kind, source?

            //return View(await mealContext.ToListAsync());
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
            var Menu = new Menu();
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            Menu.MenuChoices = new List<MenuChoice>();

            PopulateAssignedRecipeData(_context, Menu);
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuID,MenuName,MealPlan,UsersId")] Menu menu, string[] selectedRecipes)
        {
            if (selectedRecipes != null)
            {
                menu.MenuChoices = new List<MenuChoice>();
                foreach (var recipe in selectedRecipes)
                {
                    var RecipeToAdd = new MenuChoice { MenuID = menu.MenuID, RecipeID = int.Parse(recipe) };
                    menu.MenuChoices.Add(RecipeToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "FirstName", menu.UsersId);
            PopulateAssignedRecipeData(_context, menu);
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

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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


            //var menuToUpdate = await _context.Menus.SingleOrDefaultAsync(m => m.MenuID == id);


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

            //return View(menuToUpdate);
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
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
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
