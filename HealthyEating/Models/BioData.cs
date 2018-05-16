using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Models
{
    public class BioData
    {
        public enum ActivityLevels
        {
            [Display(Name = "Sedentary or light activity")]
            Sedentary = 1,
            [Display(Name = "Active or moderately active")]
            Active = 2,
            [Display(Name = "Vigorously active")]
            Very = 3
        }

        public enum Genders
        {
            Female = 'F',
            Male = 'M'
        }

        public enum Goals
        {
            [Display(Name = "Weight Gain ")]
            Gain = 1,
            [Display(Name = "Maintain Weight")]
            Maintain = 2,
            [Display(Name = "Lose weight")]
            Lose = 3
        }


        [Key]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Display(Name = "Activity Level")]
        [Required]
        public ActivityLevels ActivityLevel { get; set; }

        public Goals Goal { get; set; } = Goals.Maintain;

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Range(35, 250)]
        public int Height { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use nu only please")]
        [Range(35, 250)]
        public int Weight { get; set; }

        [Required]
        public Genders Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Age")]
        public int Aget
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - Birthday.Year;
                if (Birthday > now.AddYears(-age)) age--;
                return age;
            }
        }

        [Display(Name = "Energy Requirement to reach goal")]
        public double AMR
        {
            get
            {
                //Constant k for Gender specific value
                int k;
                //Constant e for caloric adjustment based on their goals
                int e;
                //Constant ar to adjust the basal metabolic rate to active metabolic rate.
                double ar;

                if (Gender == Genders.Female)
                    k = -161;
                else
                    k = 5;

                if (ActivityLevel == ActivityLevels.Sedentary)
                { ar = 1.53; }
                else if (ActivityLevel == ActivityLevels.Active)
                { ar = 1.76; }
                else
                { ar = 2.25; }

                if (Goal == Goals.Lose)
                { e = -500; }
                else if (ActivityLevel == ActivityLevels.Active)
                { e = 500; }
                else
                { e = 0; }

                double BMR = e + (10 * Weight + 6.25 * Height - 5 * Aget - k) * ar;

                return Convert.ToInt16(BMR);

            }
        }



        public ApplicationUser Users { get; set; }
    }
}
