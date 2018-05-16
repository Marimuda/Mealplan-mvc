using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEating.Models.MealViewModels
{
    public class RecipeCounter
    {
        public int? RecipeID { get; set; }
        public int? RecipeScore { get; set; }
        public int RecipeCount { get; set; }
    }
}
