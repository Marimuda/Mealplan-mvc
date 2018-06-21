using HealthyEating.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyEating.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeRating> RecipeRatings { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MenuChoice> MenuChoices { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<BioData> BioDatas { get; set; }
        public virtual DbSet<RecipeType> RecipeTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Recipe>().ToTable("Recipe");
            builder.Entity<RecipeRating>().ToTable("RecipeRating");
            builder.Entity<RecipeIngredient>().ToTable("RecipeIngredient");
            builder.Entity<Ingredient>().ToTable("Ingredient");
            builder.Entity<MenuChoice>().ToTable("MenuChoice");
            builder.Entity<Menu>().ToTable("Menu");
            builder.Entity<ApplicationUser>().ToTable("AspNetUser");
            builder.Entity<RecipeType>().ToTable("RecipeType");

            builder.Entity<RecipeIngredient>()
            .HasKey(c => new { c.IngredientID, c.RecipeID });

            builder.Entity<ApplicationUser>()
            .HasOne(a => a.BioDatas)
            .WithOne(b => b.Users)
            .HasForeignKey<BioData>(b => b.UserID);

        }


        public DbSet<HealthyEating.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
