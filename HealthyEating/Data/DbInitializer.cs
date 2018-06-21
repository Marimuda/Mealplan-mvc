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

            // Look for any user.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var passwordHasher = new PasswordHasher();
            var users = new ApplicationUser[]
            {
                new ApplicationUser{Id="0c755b90-466e-4346-8955-d42da4727fce", LastName = "Petersen", FirstName = "Jesper", Email = "Superman132@arto.dk", NormalizedEmail = "SUPERMAN132@ARTO.DK", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Superman132", NormalizedUserName = "SUPERMAN132", LockoutEnabled = true},
                new ApplicationUser{Id="15edb9e0-e236-4c62-8370-c11f0dfc0383", LastName = "Hansen", FirstName = "Peter", Email = "Flawless12@Hotmail.com", NormalizedEmail = "FLAWLESS12@HOTMAIL.COM", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Flawless12", NormalizedUserName = "FLAWLESS12", LockoutEnabled = true},
                new ApplicationUser{Id="202524bb-dc0b-4fbd-b1ca-b955cd643327", LastName = "Olsen", FirstName = "Fredrik", Email = "Olsen1502@gmail.com" , NormalizedEmail = "OLSEN1502@GMAIL.COM", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Olsen1502", NormalizedUserName = "OLSEN1502", LockoutEnabled = true},
                new ApplicationUser{Id="311a0673-4caa-4c47-986d-4e4102202658", LastName = "Raval", FirstName = "Siraj", Email = "FemaleHunter11@date.dk" , NormalizedEmail = "FEMALEHUNTER11@DATE.DK", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="FemaleHunter11", NormalizedUserName = "FEMALEHUNTER11", LockoutEnabled = true},
                new ApplicationUser{Id="5068855a-7c4b-4353-a4dd-62956258dc7c", LastName = "Obama", FirstName = "Barack", Email = "Baracko@usa.gov" , NormalizedEmail = "BARACKO@USA.GOV", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Baracko", NormalizedUserName = "BARACKO", LockoutEnabled = true},
                new ApplicationUser{Id="564ce587-d697-4625-9331-cd22602c0199", LastName = "Lamhauge", FirstName = "Putin", Email = "Okcarab@rus.ru", NormalizedEmail = "OKCARAB@RUS.RU", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Okcarab", NormalizedUserName = "OKCARAB", LockoutEnabled = true},
                new ApplicationUser{Id="6630b34e-97c9-4bda-bf3e-57fc9936fd2a", LastName = "Magnussen", FirstName = "Bill", Email = "Hero@guitar.dk" , NormalizedEmail = "HERO@GUITAR.DK", PasswordHash = passwordHasher.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString(), UserName ="Hero", NormalizedUserName = "HERO", LockoutEnabled = true}

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
                    new Ingredient{IngredientID = 105, IngredientName = "Bacon", Protein = 12.6, Carbohydrates = 1.3, Fat = 39.7 },
                    new Ingredient{IngredientID = 106, IngredientName = "Ham", Protein = 17.9, Carbohydrates = 0, Fat = 3.5 },
                    new Ingredient{IngredientID = 107, IngredientName = "Squid", Protein = 15.6, Carbohydrates = 3.1, Fat = 1.4 },
                    new Ingredient{IngredientID = 108, IngredientName = "Lobster", Protein = 16.5, Carbohydrates = 0, Fat = 0.8 },
                    new Ingredient{IngredientID = 109, IngredientName = "Caviar", Protein = 24.6, Carbohydrates = 4, Fat = 17.9 },
                    new Ingredient{IngredientID = 110, IngredientName = "Mackerel", Protein = 20, Carbohydrates = 3.6, Fat = 24.6 },
                    new Ingredient{IngredientID = 111, IngredientName = "Shrimp", Protein = 20.1, Carbohydrates = 0, Fat = 0.5 },
                    new Ingredient{IngredientID = 112, IngredientName = "Tuna", Protein = 24.4, Carbohydrates = 0, Fat = 0.5 },
                    new Ingredient{IngredientID = 113, IngredientName = "Duck liver", Protein = 18, Carbohydrates = 3.5, Fat = 4.6 },
                    new Ingredient{IngredientID = 114, IngredientName = "Chicken nugget, frost", Protein = 15.3, Carbohydrates = 12.3, Fat = 13.2 },
                    new Ingredient{IngredientID = 115, IngredientName = "Chicken, breast fillet", Protein = 22.5, Carbohydrates = 0, Fat = 2.6 },
                    new Ingredient{IngredientID = 116, IngredientName = "Goose", Protein = 11.4, Carbohydrates = 0, Fat = 15.9 },

                    new Ingredient{IngredientID = 201, IngredientName = "Potato", Protein = 2, Carbohydrates = 17, Fat = 0.1  },
                    new Ingredient{IngredientID = 202, IngredientName = "White Rice", Protein = 2.7, Carbohydrates = 28, Fat = 0.3  },
                    new Ingredient{IngredientID = 203, IngredientName = "Jasmine Rice", Protein = 4.2, Carbohydrates = 44.5, Fat = 0.4  },
                    new Ingredient{IngredientID = 204, IngredientName = "Pasta", Protein = 5, Carbohydrates = 25, Fat = 1.1  },

                    new Ingredient{IngredientID = 301, IngredientName = "Avocado", Protein = 2, Carbohydrates = 9, Fat = 15  },
                    new Ingredient{IngredientID = 302, IngredientName = "Almond", Protein = 21, Carbohydrates = 22, Fat = 49  },
                    new Ingredient{IngredientID = 303, IngredientName = "Peanut", Protein = 26, Carbohydrates = 16, Fat = 49  },
                    new Ingredient{IngredientID = 304, IngredientName = "Walnut", Protein = 15, Carbohydrates = 14, Fat = 65  },

                    new Ingredient{IngredientID = 401, IngredientName = "Banana", Protein = 1.3, Carbohydrates = 19, Fat = 0.3  },
                    new Ingredient{IngredientID = 402, IngredientName = "Yogurt naturel", Protein = 3.8, Carbohydrates = 3.8, Fat = 3.6  },
                    new Ingredient{IngredientID = 403, IngredientName = "Honey", Protein = 0.3, Carbohydrates = 82, Fat = 0  },
                    new Ingredient{IngredientID = 404, IngredientName = "Blueberry", Protein = 0.7, Carbohydrates = 14.8, Fat = 0.3  },

                    new Ingredient{IngredientID = 501, IngredientName = "Cucumber with peel", Protein = 0.7, Carbohydrates = 2.1, Fat = 0.1  },
                    new Ingredient{IngredientID = 502, IngredientName = "Broccoli", Protein = 2.8, Carbohydrates = 6.5, Fat = 0.4  },
                    new Ingredient{IngredientID = 503, IngredientName = "Spinach", Protein = 2.9, Carbohydrates = 3.6, Fat = 0.4  },
                    new Ingredient{IngredientID = 504, IngredientName = "White cabbage", Protein = 1.3, Carbohydrates = 5.8, Fat = 0.1  },

                    new Ingredient{IngredientID = 601, IngredientName = "Kidney beans, boiled", Protein = 8.7, Carbohydrates = 22.8, Fat = 0.5  },
                    new Ingredient{IngredientID = 602, IngredientName = "Asparagus, white", Protein = 2, Carbohydrates = 4.9, Fat = 0.2  },
                    new Ingredient{IngredientID = 603, IngredientName = "Basil", Protein = 3.2, Carbohydrates = 2.7, Fat = 0.6  },
                    new Ingredient{IngredientID = 604, IngredientName = "Artichoke", Protein = 3.3, Carbohydrates = 10.5, Fat = 0.2 },

                    new Ingredient{IngredientID = 701, IngredientName = "Bulgur", Protein = 12.3, Carbohydrates = 75.9, Fat = 1.3 },
                    new Ingredient{IngredientID = 702, IngredientName = "White bread", Protein = 10.7, Carbohydrates = 52, Fat = 2.4 },
                    new Ingredient{IngredientID = 703, IngredientName = "Rye bread, dark", Protein = 5.5, Carbohydrates = 37, Fat = 1.6 },
                    new Ingredient{IngredientID = 704, IngredientName = "Tortilla, whole wheat", Protein = 9.8, Carbohydrates = 45.9, Fat = 9.8 },

                };

            foreach (Ingredient i in Ingredients)
            {
                context.Ingredients.Add(i);
            }
            context.SaveChanges();

            var Recipes = new Recipe[]
                {
                    new Recipe{RecipeID = 1, RecipeName = "Garlic Butter Salmon" , RecipeCreationTime = DateTime.Parse("23-07-2017")  ,RecipeImage = "/Garlic-Butter-Baked-Salmon_exps40088_REM1437855C08_06_1b_RMS.jpg" , RecipeDescription = "Directions: Preheat oven to 375 degrees F. Line a baking sheet with foil. In a small bowl, add lemon juice, garlic, and melted butter. Place salmon on prepared baking sheet. Pour the butter mixture over the salmon. Season with salt, pepper, oregano, and red pepper flakes. Fold the sides of the foil over the salmon.", UsersId = "0c755b90-466e-4346-8955-d42da4727fce" },
                    new Recipe{RecipeID = 2, RecipeName = "Oven-Roasted Turkey Breast" , RecipeCreationTime = DateTime.Parse("18-02-2018")  ,RecipeImage = "/ff5a14ce-0e32-442e-9249-22812d06e8b5.jpg" , RecipeDescription = "Directions. Preheat oven to 350 degrees F (175 degrees C). Mix 1/4 cup butter, garlic, paprika, Italian seasoning, garlic and herb seasoning, salt, and black pepper in a bowl. Roast in the preheated oven for 1 hour; baste turkey breast with remaining butter mixture.", UsersId = "0c755b90-466e-4346-8955-d42da4727fce" },
                    new Recipe{RecipeID = 3, RecipeName = "Smothered Chicken Breasts" , RecipeCreationTime = DateTime.Parse("10-01-2016")  ,RecipeImage = "/Smothered-Chicken-Breasts_EXPS_SDON17_32248_B07_06_2b.jpg" , RecipeDescription = "After trying this delicious chicken dish in a restaurant, I decided to recreate it at home. Topped with bacon, caramelized onions and zippy shredded cheese, it comes together in no time with ingredients I usually have on hand. Plus, it cooks in one skillet, so it's a cinch to clean up! —Brenda Carpenter, Warrensburg, Missouri.", UsersId = "5068855a-7c4b-4353-a4dd-62956258dc7c"  },
                    new Recipe{RecipeID = 4, RecipeName = "Greek-Style Baked Cod" , RecipeCreationTime = DateTime.Parse("21-04-2018")  ,RecipeImage = "/bakaliaro-plaki.jpg" , RecipeDescription = "Coat both sides of cod in melted butter in the baking dish. Bake cod in the preheated oven for 10 minutes. Remove from oven; top with lemon juice, wine, and cracker mixture. Place back in oven and bake until fish is opaque and flakes easily with a fork, about 10 more minutes.", UsersId = "5068855a-7c4b-4353-a4dd-62956258dc7c"  },
                    new Recipe{RecipeID = 5, RecipeName = "Creamy tomato soup" , RecipeCreationTime = DateTime.Parse("15-05-2016")  ,RecipeImage = "/Creamy-tomato-soup.jpg" , RecipeDescription = "Put the oil, onions, celery, carrots, potatoes and bay leaves in a big casserole dish, or two saucepans. Fry gently until the onions are softened – about 10-15 mins. Fill the kettle and boil it. Stir in the tomato purée, sugar, vinegar, chopped tomatoes and passata, then crumble in the stock cubes. Add 1 litre boiling water and bring to a simmer. Cover and simmer for 15 mins until the potato is tender, then remove the bay leaves. Purée with a stick blender (or ladle into a blender in batches) until very smooth. Season to taste and add a pinch more sugar if it needs it. The soup can now be cooled and chilled for up to 2 days, or frozen for up to 3 months. To serve, reheat the soup, stirring in the milk – try not to let it boil.", UsersId = "6630b34e-97c9-4bda-bf3e-57fc9936fd2a" },
                    new Recipe{RecipeID = 6, RecipeName = "Watermelon, prawn & avocado salad" , RecipeCreationTime = DateTime.Parse("20-03-2015")  ,RecipeImage = "/Watermelon,-prawn-and-avocado-salad.jpg" , RecipeDescription = "Put the onion in a medium bowl with the garlic, chilli, lime juice, vinegar, sugar and some seasoning. Leave to marinate for 10 mins.Add the watermelon, avocado, coriander and prawns, then toss gently to serve.", UsersId = "564ce587-d697-4625-9331-cd22602c0199" },
                    new Recipe{RecipeID = 7, RecipeName = "Cranberry chicken salad" , RecipeCreationTime = DateTime.Parse("19-04-2018")  ,RecipeImage = "/Cranberry-chicken-salas.jpg" , RecipeDescription = "Slice each chicken breast in half horizontally to give 4 thin breasts, then rub with half the oil and season. Heat a non-stick frying pan and fry the chicken for 3 mins on each side until cooked through. Set aside on a plate.Heat the remaining oil in the pan and fry the onions for 5 mins. Slice the chicken, collecting any juices, and layer up with the onions, leaves, cucumber and dried cranberries. Mix the cranberry sauce, lime juice, 2 tbsp water and any chicken resting juices, and drizzle over the salad.", UsersId = "15edb9e0-e236-4c62-8370-c11f0dfc0383" },
                    new Recipe{RecipeID = 8, RecipeName = "Teriyaki steak with fennel slaw" , RecipeCreationTime = DateTime.Parse("03-05-2014")  ,RecipeImage = "/Teriyaki-steak-with-fennel-slaw.jpg" , RecipeDescription = "Mix the soy, vinegar and honey, add the steaks, then marinate for 10-15 mins. Toss together the carrot, fennel, onion and coriander, then chill until ready to serve. Cook the steaks in a griddle pan for a few mins on each side, depending on the thickness and how well done you like them. Set the meat aside to rest on a plate, then add the remaining marinade to the pan. Bubble the marinade until it reduces a little to make a sticky sauce. Dress the salad with the lime juice, then pile onto plates and serve with the steaks. Spoon the sauce over the meat.", UsersId = "0c755b90-466e-4346-8955-d42da4727fce" },
                    new Recipe{RecipeID = 9, RecipeName = "Green mango salad with prawns" , RecipeCreationTime = DateTime.Parse("12-01-2017")  ,RecipeImage = "/Green-mango-salad-with-prawns.jpg" , RecipeDescription = "Mix together the lime juice, chilli, fish sauce and sugar in a large bowl. Add the shallots and three quarters of the peanuts and mix well. Cover and set aside for up to 4 hours. Peel and coarsely grate the mango or apple, and stir into the mixture along with the mint. Heat the oil in a frying pan or wok, add the prawns and stir fry quickly until evenly pink – about 2 minutes. Scatter the lettuce leaves on a serving plate and spoon the salad mixture in the centre. Surround with the prawns and scatter over the remaining peanuts and spring onions.", UsersId = "15edb9e0-e236-4c62-8370-c11f0dfc0383" },
                    new Recipe{RecipeID = 10, RecipeName = "Cheesy fish grills" , RecipeCreationTime = DateTime.Parse("26-06-2016")  ,RecipeImage = "/Cheesy-fish-grills.jpg" , RecipeDescription = "Preheat the grill to high and lightly oil a large shallow heatproof dish. Arrange the fillets in the dish, slightly spaced apart, and brush them with a little oil. Grill for 2 minutes. Remove the dish from the grill, turn the fish over and top each fillet with a scrunched slice of ham. Mix together the cheese and onions, scatter over the fish and season with salt and pepper. Return to the grill for 5 minutes until the fish flakes easily when prodded with a knife. Serve with green vegetables – broccoli or stir-fried cabbage would be good.", UsersId = "6630b34e-97c9-4bda-bf3e-57fc9936fd2a" },
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
                    new RecipeIngredient{ID =12, RecipeID = 4, IngredientID = 304, Amount = 35 },
                    new RecipeIngredient{ID =13, RecipeID = 3, IngredientID = 110, Amount = 250 },
                    new RecipeIngredient{ID =14, RecipeID = 3, IngredientID = 601, Amount = 130 },
                    new RecipeIngredient{ID =15, RecipeID = 4, IngredientID = 701, Amount = 50 },
                    new RecipeIngredient{ID =16, RecipeID = 4, IngredientID = 202, Amount = 35 }

    };

            foreach (RecipeIngredient i in RecipeIngredients)
            {
                context.RecipeIngredients.Add(i);
            }


            var RecipeRatings = new RecipeRating[]
                {
                    new RecipeRating{ID =1, RecipeID = 1, UsersId = "0c755b90-466e-4346-8955-d42da4727fce", Score = 1 },
                    new RecipeRating{ID =2, RecipeID = 1, UsersId = "202524bb-dc0b-4fbd-b1ca-b955cd643327", Score = 1 },
                    new RecipeRating{ID =3, RecipeID = 1, UsersId = "564ce587-d697-4625-9331-cd22602c0199", Score = 1 },
                    new RecipeRating{ID =4, RecipeID = 1, UsersId = "6630b34e-97c9-4bda-bf3e-57fc9936fd2a", Score = 1 },
                    new RecipeRating{ID =5, RecipeID = 2, UsersId = "0c755b90-466e-4346-8955-d42da4727fce", Score = -1 },
                    new RecipeRating{ID =6, RecipeID = 2, UsersId = "15edb9e0-e236-4c62-8370-c11f0dfc0383", Score = -1 },
                    new RecipeRating{ID =7, RecipeID = 2, UsersId = "311a0673-4caa-4c47-986d-4e4102202658", Score = -1 },
                    new RecipeRating{ID =8, RecipeID = 3, UsersId = "564ce587-d697-4625-9331-cd22602c0199", Score = -1 },
                    new RecipeRating{ID =9, RecipeID = 3, UsersId = "15edb9e0-e236-4c62-8370-c11f0dfc0383", Score = -1 },
                    new RecipeRating{ID =10, RecipeID = 3, UsersId = "6630b34e-97c9-4bda-bf3e-57fc9936fd2a", Score = 1 },
                    new RecipeRating{ID =11, RecipeID = 4, UsersId = "0c755b90-466e-4346-8955-d42da4727fce", Score = 1 },
                    new RecipeRating{ID =12, RecipeID = 4, UsersId = "202524bb-dc0b-4fbd-b1ca-b955cd643327", Score = -1 }

                };

            foreach (RecipeRating rr in RecipeRatings)
            {
                context.RecipeRatings.Add(rr);
            }
            context.SaveChanges();




            var Menus = new Menu[]
                {
                    new Menu{MenuID =1, MenuName = "Healthy Weight Loss", MealPlan = Menu.MealPlans.True, UsersId = "0c755b90-466e-4346-8955-d42da4727fce" },
                    new Menu{MenuID =2, MenuName = "Dirty Gains", MealPlan = Menu.MealPlans.False, UsersId = "202524bb-dc0b-4fbd-b1ca-b955cd643327"},
                    new Menu{MenuID =3, MenuName = "Paleo Diet", MealPlan = Menu.MealPlans.False, UsersId = "15edb9e0-e236-4c62-8370-c11f0dfc0383"},
                    new Menu{MenuID =4, MenuName = "Vegan gains", MealPlan = Menu.MealPlans.False, UsersId = "6630b34e-97c9-4bda-bf3e-57fc9936fd2a"}

                };

            foreach (Menu m in Menus)
            {
                context.Menus.Add(m);
            }
            context.SaveChanges();


            var RecipeTypes = new RecipeType[]
    {
                    new RecipeType{ID =1, CourseType = "Breakfast"},
                    new RecipeType{ID =2, CourseType = "Brunch"},
                    new RecipeType{ID =3, CourseType = "Elevenses"},
                    new RecipeType{ID =4, CourseType = "Lunch"},
                    new RecipeType{ID =5, CourseType = "Supper"},
                    new RecipeType{ID =6, CourseType = "Dinner"},
    };

            foreach (RecipeType r in RecipeTypes)
            {
                context.RecipeTypes.Add(r);
            }
            context.SaveChanges();


            var MenuChoices = new MenuChoice[]
                {
                    new MenuChoice{ID =1, MenuID = 1, RecipeID = 1, RecipeTypeID = 1},
                    new MenuChoice{ID =2, MenuID = 1, RecipeID = 2, RecipeTypeID = 2},
                    new MenuChoice{ID =3, MenuID = 1, RecipeID = 3, RecipeTypeID = 4},
                    new MenuChoice{ID =4, MenuID = 1, RecipeID = 4, RecipeTypeID = 5},
                    new MenuChoice{ID =5, MenuID = 1, RecipeID = 4, RecipeTypeID = 6},
                    new MenuChoice{ID =6, MenuID = 2, RecipeID = 1, RecipeTypeID = 1},
                    new MenuChoice{ID =7, MenuID = 2, RecipeID = 1, RecipeTypeID = 2},
                    new MenuChoice{ID =8, MenuID = 2, RecipeID = 1, RecipeTypeID = 4},
                    new MenuChoice{ID =9, MenuID = 2, RecipeID = 3, RecipeTypeID = 1},
                    new MenuChoice{ID =10, MenuID = 3, RecipeID = 2, RecipeTypeID = 1},
                    new MenuChoice{ID =11, MenuID = 3, RecipeID = 2, RecipeTypeID = 2},
                    new MenuChoice{ID =12, MenuID = 3, RecipeID = 4, RecipeTypeID = 4},
                    new MenuChoice{ID =13, MenuID = 3, RecipeID = 3, RecipeTypeID = 6},
                    new MenuChoice{ID =14, MenuID = 4, RecipeID = 2, RecipeTypeID = 1},
                    new MenuChoice{ID =15, MenuID = 4, RecipeID = 3, RecipeTypeID = 2},
                    new MenuChoice{ID =16, MenuID = 4, RecipeID = 4, RecipeTypeID = 4},
                    new MenuChoice{ID =17, MenuID = 4, RecipeID = 2, RecipeTypeID = 6}

                };

            foreach (MenuChoice m in MenuChoices)
            {
                context.MenuChoices.Add(m);
            }
            context.SaveChanges();


            var Biodatas = new BioData[]
                {
                     new BioData{UserID = "0c755b90-466e-4346-8955-d42da4727fce", Height = 195, Weight = 103, ActivityLevel = BioData.ActivityLevels.Very, Gender = BioData.Genders.Female, Goal = BioData.Goals.Gain, Birthday = DateTime.Parse("06-06-1955") },
                     new BioData{UserID = "15edb9e0-e236-4c62-8370-c11f0dfc0383", Height = 183, Weight = 86, ActivityLevel = BioData.ActivityLevels.Active, Gender = BioData.Genders.Male, Goal = BioData.Goals.Gain, Birthday = DateTime.Parse("24-11-1973") },
                     new BioData{UserID = "202524bb-dc0b-4fbd-b1ca-b955cd643327", Height = 172, Weight = 75, ActivityLevel = BioData.ActivityLevels.Sedentary, Gender = BioData.Genders.Male, Goal = BioData.Goals.Maintain, Birthday = DateTime.Parse("01-01-1980") },
                     new BioData{UserID = "311a0673-4caa-4c47-986d-4e4102202658", Height = 171, Weight = 53, ActivityLevel = BioData.ActivityLevels.Very, Gender = BioData.Genders.Female, Goal = BioData.Goals.Lose, Birthday = DateTime.Parse("11-09-1990") },
                     new BioData{UserID = "5068855a-7c4b-4353-a4dd-62956258dc7c", Height = 166, Weight = 58, ActivityLevel = BioData.ActivityLevels.Active, Gender = BioData.Genders.Female, Goal = BioData.Goals.Maintain, Birthday = DateTime.Parse("09-01-1968") },
                     new BioData{UserID = "564ce587-d697-4625-9331-cd22602c0199", Height = 151, Weight = 49, ActivityLevel = BioData.ActivityLevels.Sedentary, Gender = BioData.Genders.Female, Goal = BioData.Goals.Lose, Birthday = DateTime.Parse("23-09-2000") },
                     new BioData{UserID = "6630b34e-97c9-4bda-bf3e-57fc9936fd2a", Height = 163, Weight = 62, ActivityLevel = BioData.ActivityLevels.Active, Gender = BioData.Genders.Male, Goal = BioData.Goals.Gain, Birthday = DateTime.Parse("10-07-1984") }
                };

            foreach (BioData b in Biodatas)
            {
                context.BioDatas.Add(b);
            }
            context.SaveChanges();

        }

    }
}
