namespace HealthyEating.Models.MealViewModels
{
    public class AssignedRecipes
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }

        public bool Assigned { get; set; }
    }
}
