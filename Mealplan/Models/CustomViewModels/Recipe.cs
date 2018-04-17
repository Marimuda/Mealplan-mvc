using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mealplan.Models.CustomViewModels
{
    public partial class Recipe
    {
        public int RecipeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReCreationDate { get; set; }

        public string RecipeDescription { get; set; }
        public string RecipeName { get; set; }
        public string UserId { get; set; }

        public Aspnetusers User { get; set; }
        public ICollection<Reciperatning> Reciperatnings { get; set; }
    }
}
