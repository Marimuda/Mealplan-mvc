using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Models
{
    public class RecipeType
    {


        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Type name cannot be longer than 50 characters.")]
        [Display(Name = "Course Type")]
        public string CourseType { get; set; }

        public ICollection<MenuChoice> MenuChoices { get; set; }
    }
}
