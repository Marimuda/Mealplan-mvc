using System;
using System.Collections.Generic;

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

        public Aspnetusers User { get; set; }
    }
}
