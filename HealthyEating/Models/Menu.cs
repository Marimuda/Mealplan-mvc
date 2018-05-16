using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Models
{
    public class Menu
    {
        public enum MealPlans
        {
            True,
            False
        }


        [Display(Name = "ID")]
        public int MenuID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Recipe name cannot be longer than 50 characters.")]
        [Display(Name = "Menu Name")]
        public string MenuName { get; set; }
        [Display(Name = "Mealplan Dispay")]
        public MealPlans? MealPlan { get; set; }
        [Display(Name = "User ID")]
        public string UsersId { get; set; }

        public ApplicationUser Users { get; set; }
        public ICollection<MenuChoice> MenuChoices { get; set; }
    }
}
