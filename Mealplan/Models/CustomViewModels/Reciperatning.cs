using System.ComponentModel.DataAnnotations;

namespace Mealplan.Models.CustomViewModels
{
    public partial class Reciperatning
    {
        [Key]
        public int RecipeId { get; set; }
        [Range(-1, 1)]
        public short RecipeRating { get; set; }

        public Recipe Recipe { get; set; }
    }
}
