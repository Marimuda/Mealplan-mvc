using HealthyEating.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace HealthyEating.Data
{
    public static class DbInitializer
    {

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var passwordHasher = new PasswordHasher();
            var users = new ApplicationUser[]
            {
                new ApplicationUser{Id="test1", LastName = "Petersen", FirstName = "Jesper", Email = "Superman132@arto.dk", NormalizedEmail = "SUPERMAN132@ARTO.DK", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Superman132", NormalizedUserName = "SUPERMAN132", LockoutEnabled = true},
                new ApplicationUser{Id="test2", LastName = "Hansen", FirstName = "Peter", Email = "Flawless12@Hotmail.com", NormalizedEmail = "FLAWLESS12@HOTMAIL.COM", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Flawless12", NormalizedUserName = "FLAWLESS12", LockoutEnabled = true},
                new ApplicationUser{Id="test3", LastName = "Olsen", FirstName = "Fredrik", Email = "Olsen1502@gmail.com" , NormalizedEmail = "OLSEN1502@GMAIL.COM", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Olsen1502", NormalizedUserName = "OLSEN1502", LockoutEnabled = true},
                new ApplicationUser{Id="test4", LastName = "Raval", FirstName = "Siraj", Email = "FemaleHunter11@date.dk" , NormalizedEmail = "FEMALEHUNTER11@DATE.DK", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="FemaleHunter11", NormalizedUserName = "FEMALEHUNTER11", LockoutEnabled = true},
                new ApplicationUser{Id="test5", LastName = "Obama", FirstName = "Barack", Email = "Baracko@usa.gov" , NormalizedEmail = "BARACKO@USA.GOV", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Baracko", NormalizedUserName = "BARACKO", LockoutEnabled = true},
                new ApplicationUser{Id="test6", LastName = "Lamhauge", FirstName = "Putin", Email = "Okcarab@rus.ru", NormalizedEmail = "OKCARAB@RUS.RU", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Okcarab", NormalizedUserName = "OKCARAB", LockoutEnabled = true},
                new ApplicationUser{Id="test7", LastName = "Magnussen", FirstName = "Bill", Email = "Hero@guitar.dk" , NormalizedEmail = "HERO@GUITAR.DK", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Hero", NormalizedUserName = "HERO", LockoutEnabled = true}

            };

            foreach (ApplicationUser u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();


            var identityRoles = new IdentityRole[]
    {
                    new IdentityRole{Id = "1", ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole{Id = "2", ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "Moderator", NormalizedName = "MODERATOR" },
                    new IdentityRole{Id = "3", ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" },
    };
            foreach (IdentityRole i in identityRoles)
            {
                context.Roles.Add(i);
            }
            context.SaveChanges();

            var Ingredients = new Ingredient[]
                {
                    new Ingredient{IngredientID = 101, IngredientName = "Chicken Breast", Protein = 31, Carbohydrates = 0, Fat = 3.6  },
                    new Ingredient{IngredientID = 102, IngredientName = "Turkey Breast", Protein = 22, Carbohydrates = 0, Fat = 7  },
                    new Ingredient{IngredientID = 103, IngredientName = "Atlantic Salmon", Protein = 20, Carbohydrates = 0, Fat = 13  },
                    new Ingredient{IngredientID = 104, IngredientName = "Atlantic Cod", Protein = 18, Carbohydrates = 0, Fat = 0.7  },

                    new Ingredient{IngredientID = 201, IngredientName = "Potato", Protein = 2, Carbohydrates = 17, Fat = 0.1  },
                    new Ingredient{IngredientID = 202, IngredientName = "White Rice", Protein = 2.7, Carbohydrates = 28, Fat = 0.3  },
                    new Ingredient{IngredientID = 203, IngredientName = "Jasmine Rice", Protein = 4.2, Carbohydrates = 44.5, Fat = 0.4  },
                    new Ingredient{IngredientID = 204, IngredientName = "Pasta", Protein = 5, Carbohydrates = 25, Fat = 1.1  },

                    new Ingredient{IngredientID = 301, IngredientName = "Avocado", Protein = 2, Carbohydrates = 9, Fat = 15  },
                    new Ingredient{IngredientID = 302, IngredientName = "Almond", Protein = 21, Carbohydrates = 22, Fat = 49  },
                    new Ingredient{IngredientID = 303, IngredientName = "Peanut", Protein = 26, Carbohydrates = 16, Fat = 49  },
                    new Ingredient{IngredientID = 304, IngredientName = "Walnut", Protein = 15, Carbohydrates = 14, Fat = 65  }
                };

            foreach (Ingredient i in Ingredients)
            {
                context.Ingredients.Add(i);
            }
            context.SaveChanges();

            var Recipes = new Recipe[]
                {
                    new Recipe{RecipeID = 1, RecipeName = "Garlic Butter Salmon" , RecipeCreationTime = DateTime.Parse("23-07-2017")  , /*RecipeRatning = 36, */ RecipeImage = "/Garlic-Butter-Baked-Salmon_exps40088_REM1437855C08_06_1b_RMS.jpg" , RecipeDescription = "Directions: Preheat oven to 375 degrees F. Line a baking sheet with foil. In a small bowl, add lemon juice, garlic, and melted butter. Place salmon on prepared baking sheet. Pour the butter mixture over the salmon. Season with salt, pepper, oregano, and red pepper flakes. Fold the sides of the foil over the salmon.", UsersId = "test1" },
                    new Recipe{RecipeID = 2, RecipeName = "Oven-Roasted Turkey Breast" , RecipeCreationTime = DateTime.Parse("18-02-2018")  ,/* RecipeRatning = 7, */ RecipeImage = "/ff5a14ce-0e32-442e-9249-22812d06e8b5.jpg" , RecipeDescription = "Directions. Preheat oven to 350 degrees F (175 degrees C). Mix 1/4 cup butter, garlic, paprika, Italian seasoning, garlic and herb seasoning, salt, and black pepper in a bowl. Roast in the preheated oven for 1 hour; baste turkey breast with remaining butter mixture.", UsersId = "test1" },
                    new Recipe{RecipeID = 3, RecipeName = "Smothered Chicken Breasts" , RecipeCreationTime = DateTime.Parse("10-01-2016")  ,/* RecipeRatning = -25, */ RecipeImage = "/Smothered-Chicken-Breasts_EXPS_SDON17_32248_B07_06_2b.jpg" , RecipeDescription = "After trying this delicious chicken dish in a restaurant, I decided to recreate it at home. Topped with bacon, caramelized onions and zippy shredded cheese, it comes together in no time with ingredients I usually have on hand. Plus, it cooks in one skillet, so it's a cinch to clean up! —Brenda Carpenter, Warrensburg, Missouri.", UsersId = "test5"  },
                    new Recipe{RecipeID = 4, RecipeName = "Greek-Style Baked Cod" , RecipeCreationTime = DateTime.Parse("21-04-2018")  ,/* RecipeRatning = 0, */  RecipeImage = "/bakaliaro-plaki.jpg" , RecipeDescription = "Coat both sides of cod in melted butter in the baking dish. Bake cod in the preheated oven for 10 minutes. Remove from oven; top with lemon juice, wine, and cracker mixture. Place back in oven and bake until fish is opaque and flakes easily with a fork, about 10 more minutes.", UsersId = "test6"  }
                };



            foreach (Recipe r in Recipes)
            {
                context.Recipes.Add(r);
            }
            context.SaveChanges();

            var RecipeIngredients = new RecipeIngredient[]
    {
                    new RecipeIngredient{ID =1, RecipeID = 1, IngredientID = 103, Amount = 300 },
                    new RecipeIngredient{ID =2, RecipeID = 1, IngredientID = 201, Amount = 150 },
                    new RecipeIngredient{ID =3, RecipeID = 1, IngredientID = 303, Amount = 40 },
                    new RecipeIngredient{ID =4, RecipeID = 1, IngredientID = 302, Amount = 20 },
                    new RecipeIngredient{ID =5, RecipeID = 2, IngredientID = 101, Amount = 340 },
                    new RecipeIngredient{ID =6, RecipeID = 2, IngredientID = 204, Amount = 190 },
                    new RecipeIngredient{ID =7, RecipeID = 2, IngredientID = 304, Amount = 45 },
                    new RecipeIngredient{ID =8, RecipeID = 3, IngredientID = 301, Amount = 15 },
                    new RecipeIngredient{ID =9, RecipeID = 3, IngredientID = 101, Amount = 250 },
                    new RecipeIngredient{ID =10, RecipeID = 3, IngredientID = 203, Amount = 130 },
                    new RecipeIngredient{ID =11, RecipeID = 4, IngredientID = 104, Amount = 50 },
                    new RecipeIngredient{ID =12, RecipeID = 4, IngredientID = 304, Amount = 35 }

    };

            foreach (RecipeIngredient i in RecipeIngredients)
            {
                context.RecipeIngredients.Add(i);
            }


            var RecipeRatings = new RecipeRating[]
                {
                    new RecipeRating{ID =1, RecipeID = 1, UserID = "test1", Score = 1 },
                    new RecipeRating{ID =2, RecipeID = 1, UserID = "test3", Score = 1 },
                    new RecipeRating{ID =3, RecipeID = 1, UserID = "test6", Score = 1 },
                    new RecipeRating{ID =4, RecipeID = 1, UserID = "test7", Score = 1 },
                    new RecipeRating{ID =5, RecipeID = 2, UserID = "test1", Score = -1 },
                    new RecipeRating{ID =6, RecipeID = 2, UserID = "test2", Score = -1 },
                    new RecipeRating{ID =7, RecipeID = 2, UserID = "test5", Score = -1 },
                    new RecipeRating{ID =8, RecipeID = 3, UserID = "test6", Score = -1 },
                    new RecipeRating{ID =9, RecipeID = 3, UserID = "test2", Score = -1 },
                    new RecipeRating{ID =10, RecipeID = 3, UserID = "test4", Score = 1 },
                    new RecipeRating{ID =11, RecipeID = 4, UserID = "test1", Score = 1 },
                    new RecipeRating{ID =12, RecipeID = 4, UserID = "test3", Score = -1 }

                };

            foreach (RecipeRating rr in RecipeRatings)
            {
                context.RecipeRatings.Add(rr);
            }
            context.SaveChanges();




            var Menus = new Menu[]
                {
                    new Menu{MenuID =1, MenuName = "Healthy Weight Loss", MealPlan = Menu.MealPlans.True, UsersId = "test1" },
                    new Menu{MenuID =2, MenuName = "Dirty Gains", MealPlan = Menu.MealPlans.False, UsersId = "test3"},
                    new Menu{MenuID =3, MenuName = "Paleo Diet", MealPlan = Menu.MealPlans.False, UsersId = "test6"},
                    new Menu{MenuID =4, MenuName = "Vegan gains", MealPlan = Menu.MealPlans.False, UsersId = "test7"}

                };

            foreach (Menu m in Menus)
            {
                context.Menus.Add(m);
            }
            context.SaveChanges();


            var MenuChoices = new MenuChoice[]
                {
                    new MenuChoice{ID =1, MenuID = 1, RecipeID = 1},
                    new MenuChoice{ID =2, MenuID = 1, RecipeID = 2},
                    new MenuChoice{ID =3, MenuID = 1, RecipeID = 3},
                    new MenuChoice{ID =4, MenuID = 1, RecipeID = 4},
                    new MenuChoice{ID =5, MenuID = 1, RecipeID = 4},
                    new MenuChoice{ID =6, MenuID = 2, RecipeID = 1},
                    new MenuChoice{ID =7, MenuID = 2, RecipeID = 1},
                    new MenuChoice{ID =8, MenuID = 2, RecipeID = 1},
                    new MenuChoice{ID =9, MenuID = 2, RecipeID = 3},
                    new MenuChoice{ID =10, MenuID = 3, RecipeID = 2},
                    new MenuChoice{ID =11, MenuID = 3, RecipeID = 2},
                    new MenuChoice{ID =12, MenuID = 3, RecipeID = 4},
                    new MenuChoice{ID =13, MenuID = 3, RecipeID = 3},
                    new MenuChoice{ID =14, MenuID = 4, RecipeID = 2},
                    new MenuChoice{ID =15, MenuID = 4, RecipeID = 3},
                    new MenuChoice{ID =16, MenuID = 4, RecipeID = 4},
                    new MenuChoice{ID =17, MenuID = 4, RecipeID = 2}

                };

            foreach (MenuChoice m in MenuChoices)
            {
                context.MenuChoices.Add(m);
            }
            context.SaveChanges();

            var Biodatas = new BioData[]
                {
                     new BioData{UserID = "test1", Height = 195, Weight = 103, ActivityLevel = BioData.ActivityLevels.Very, Gender = BioData.Genders.Female, Goal = BioData.Goals.Gain, Birthday = DateTime.Parse("06-06-1955") },
                     new BioData{UserID = "test2", Height = 183, Weight = 86, ActivityLevel = BioData.ActivityLevels.Active, Gender = BioData.Genders.Male, Goal = BioData.Goals.Gain, Birthday = DateTime.Parse("24-11-1973") },
                     new BioData{UserID = "test3", Height = 172, Weight = 75, ActivityLevel = BioData.ActivityLevels.Sedentary, Gender = BioData.Genders.Male, Goal = BioData.Goals.Maintain, Birthday = DateTime.Parse("01-01-1980") },
                     new BioData{UserID = "test4", Height = 171, Weight = 53, ActivityLevel = BioData.ActivityLevels.Very, Gender = BioData.Genders.Female, Goal = BioData.Goals.Lose, Birthday = DateTime.Parse("11-09-1990") },
                     new BioData{UserID = "test5", Height = 166, Weight = 58, ActivityLevel = BioData.ActivityLevels.Active, Gender = BioData.Genders.Female, Goal = BioData.Goals.Maintain, Birthday = DateTime.Parse("09-01-1968") },
                     new BioData{UserID = "test6", Height = 151, Weight = 49, ActivityLevel = BioData.ActivityLevels.Sedentary, Gender = BioData.Genders.Female, Goal = BioData.Goals.Lose, Birthday = DateTime.Parse("23-09-2000") },
                     new BioData{UserID = "test7", Height = 163, Weight = 62, ActivityLevel = BioData.ActivityLevels.Active, Gender = BioData.Genders.Male, Goal = BioData.Goals.Gain, Birthday = DateTime.Parse("10-07-1984") }
                };

            foreach (BioData b in Biodatas)
            {
                context.BioDatas.Add(b);
            }
            context.SaveChanges();
        }

    }
}
