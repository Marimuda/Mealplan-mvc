using System;
using System.ComponentModel.DataAnnotations;
using static HealthyEating.Models.BioData;

namespace HealthyEating.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string StatusMessage { get; set; }

        [Display(Name = "Activity Level")]
        public ActivityLevels ActivityLevel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Birthday { get; set; }

        public Genders Gender { get; set; }

        public Goals Goals { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Range(35, 250)]
        public int Height { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Range(35, 250)]
        public int Weight { get; set; }


    }
}
