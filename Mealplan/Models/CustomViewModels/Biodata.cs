using System;

namespace Mealplan.Models.CustomViewModels
{
    public partial class Biodata
    {
        public int BioId { get; set; }
        public sbyte ActivityLevel { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public sbyte Height { get; set; }
        public string UserId { get; set; }
        public sbyte Weight { get; set; }

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

        public Aspnetusers User { get; set; }
    }
}
