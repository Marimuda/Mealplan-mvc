using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyEating.Models
{
    public class Ingredient
    {
        [Column("ID")]
        public int IngredientID { get; set; }

        [StringLength(50, ErrorMessage = "Ingredient name cannot be longer than 50 characters.")]
        [Display(Name = "Ingredient Name")]
        [Required]
        [RegularExpression(@"/^[a-zA-Z ]+$/", ErrorMessage = "Use letters only please")]
        public string IngredientName { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Required]
        [Range(1, 100)]
        public double Protein { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]   
        [Range(1, 100)]
        [Required]
        public double Carbohydrates { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Required]
        [Range(1, 100)]
        public double Fat { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
