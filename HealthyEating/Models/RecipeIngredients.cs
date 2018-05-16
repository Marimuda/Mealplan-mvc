using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Models
{
        public class RecipeIngredient
        {
            public int ID { get; set; }
            [Display(Name = "Recipe ID")]
            public int RecipeID { get; set; }
            [Display(Name = "Ingredient ID")]
            public int IngredientID { get; set; }
            [Range(1, 10000)]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
            public int Amount { get; set; }

            public Recipe Recipe { get; set; }
            public Ingredient Ingredients { get; set; }
        }
}
