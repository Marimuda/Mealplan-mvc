using System;
using System.ComponentModel.DataAnnotations;
using static HealthyEating.Models.BioData;

namespace HealthyEating.Models.AccountViewModels
{
    public class RegisterViewModel
    {

        //[Required]
        //[Display(Name = "Roles")]
        //public string UserRoles { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // [Required]
        // [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 5)]
        // [RegularExpression("^([a-zA-Z0-9]{5,20})$", ErrorMessage = "The {0} must contain only alphanumeric characters")]
        // [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public int BioId { get; set; }
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Activity Level")]
        public ActivityLevels ActivityLevel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required]
        public Genders Gender { get; set; }

        public Goals Goals { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Range(35, 250)]
        public int Height { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Range(35, 250)]
        public int Weight { get; set; }


        public string StatusMessage { get; set; }
    }
}
