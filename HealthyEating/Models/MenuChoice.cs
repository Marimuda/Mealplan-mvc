namespace HealthyEating.Models
{
    public class MenuChoice
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public int MenuID { get; set; }
        public int RecipeTypeID { get; set; }


        public Menu Menus { get; set; }
        public Recipe Recipes { get; set; }
        public RecipeType RecipeType { get; set; }
    }
}
