using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "Last Name")]
        [Required]
        public virtual string LastName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "First Name")]
        [Required]
        public virtual string FirstName { get; set; }


        public virtual string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public BioData BioDatas { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<RecipeRating> RecipeRatings { get; set; }

        public ICollection<Menu> Menus { get; set; }



    }
}
