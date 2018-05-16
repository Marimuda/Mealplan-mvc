using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mealplan.Models.CustomViewModels
{
    public partial class Recipe
    {
        [Display(Name = "Recipe Id")]
        public int RecipeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime ReCreationDate { get; set; }

        [Display(Name = "Recipe Description")]
        public string RecipeDescription { get; set; }
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        public Aspnetusers User { get; set; }
        public ICollection<Reciperatning> Reciperatnings { get; set; }
    }
}
