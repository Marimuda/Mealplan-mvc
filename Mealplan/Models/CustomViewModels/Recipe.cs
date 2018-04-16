using System;
using System.Collections.Generic;

namespace Mealplan.Models.CustomViewModels
{
    public partial class Recipe
    {
        public int RecipeId { get; set; }
        public DateTime ReCreationDate { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeName { get; set; }
        public string UserId { get; set; }

        public Aspnetusers User { get; set; }
        public Reciperatning Reciperatning { get; set; }
    }
}
