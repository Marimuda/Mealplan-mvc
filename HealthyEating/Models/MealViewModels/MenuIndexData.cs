using System.Collections.Generic;

namespace HealthyEating.Models.MealViewModels
{
    public class MenuIndexData
    {
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
        public IEnumerable<RecipeType> RecipeTypes { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<BioData> BioDatas { get; set; }
    }
}
