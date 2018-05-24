using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Models
{
    public class RecipeRating
    {
        public int ID { get; set; }
        [Required]
        [Range(-1, 1)]
        [Display(Name = "Score")]
        public int Score { get; set; }

        public int RecipeID { get; set; }
        public string UsersId { get; set; }

        public Recipe Recipes { get; set; }
        public ApplicationUser Users { get; set; }
    }
}

