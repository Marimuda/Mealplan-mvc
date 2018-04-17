using System;
using System.ComponentModel.DataAnnotations;

namespace Mealplan.Models.CustomViewModels
{
    public partial class Biodata
    {

        public enum ActivityLevels
        {

            Sedentary = 1,
            Active = 2,
            VeryActive = 3
        }
        [Display(Name = "ID")]
        public int BioId { get; set; }
        [Display(Name = "Activity Level")]
        public ActivityLevels ActivityLevel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public int Height { get; set; }
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        public int Weight { get; set; }
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

        [Display(Name = "Basal Metabolic Rate")]
        public double AMR
        {
            get
            {
                int k;

                if (Gender != "Female")
                    k = -161;
                else
                    k = 5;


                double BMR = (10 * Weight + 6.25 * Height - 5 * Aget - k);

                return BMR;

            }
        }

        public Aspnetusers User { get; set; }



    }
}
