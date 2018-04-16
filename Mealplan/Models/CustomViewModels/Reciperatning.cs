using System;
using System.Collections.Generic;

namespace Mealplan.Models.CustomViewModels
{
    public partial class Reciperatning
    {
        public int RecipeId { get; set; }
        public short? RecipeRating { get; set; }

        public Recipe Recipe { get; set; }
    }
}
