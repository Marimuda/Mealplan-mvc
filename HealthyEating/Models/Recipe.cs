using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Models
{
    public class Recipe
    {
        [Display(Name = "ID")]
        public int RecipeID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Recipe name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }
        [Display(Name = "Recipe Description")]
        [Required]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters.")]
        public string RecipeDescription { get; set; }
        [StringLength(200, ErrorMessage = "Url cannot be longer than 200 characters.")]
        [Display(Name = "Image")]
        public string RecipeImage { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Timestamp")]
        [Required]
        public DateTime? RecipeCreationTime { get; set; } = DateTime.Now;
        [Display(Name = "User ID")]
        public string UsersId { get; set; }

        public ApplicationUser Users { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<RecipeRating> RecipeRatings { get; set; }
        public ICollection<MenuChoice> MenuChoices { get; set; }

    }
}
