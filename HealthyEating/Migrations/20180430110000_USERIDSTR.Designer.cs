﻿using HealthyEating.Data;
using HealthyEating.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HealthyEating.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180430110000_USERIDSTR")]
    partial class USERIDSTR
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("HealthyEating.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUser");
                });

            modelBuilder.Entity("HealthyEating.Models.BioData", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityLevel");

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("Gender");

                    b.Property<int>("Goal");

                    b.Property<int>("Height");

                    b.Property<string>("UsersId");

                    b.Property<int>("Weight");

                    b.HasKey("UserID");

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("BioDatas");
                });

            modelBuilder.Entity("HealthyEating.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<double>("Carbohydrates");

                    b.Property<double>("Fat");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Protein");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("HealthyEating.Models.Menu", b =>
                {
                    b.Property<int>("MenuID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("MealPlan");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserID");

                    b.Property<string>("UsersId");

                    b.HasKey("MenuID");

                    b.HasIndex("UsersId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("HealthyEating.Models.MenuChoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MenuID");

                    b.Property<int>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.HasIndex("RecipeID");

                    b.ToTable("MenuChoice");
                });

            modelBuilder.Entity("HealthyEating.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("RecipeCreationTime")
                        .HasColumnName("Timestamp");

                    b.Property<string>("RecipeDescription")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<string>("RecipeImage")
                        .HasColumnName("Image")
                        .HasMaxLength(200);

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserID");

                    b.Property<string>("UsersId");

                    b.HasKey("RecipeID");

                    b.HasIndex("UsersId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("HealthyEating.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("IngredientID");

                    b.Property<int>("RecipeID");

                    b.Property<int>("Amount");

                    b.Property<int>("ID");

                    b.HasKey("IngredientID", "RecipeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("HealthyEating.Models.RecipeRating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RecipeID");

                    b.Property<int>("Score");

                    b.Property<string>("UserID");

                    b.Property<string>("UsersId");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.HasIndex("UsersId");

                    b.ToTable("RecipeRating");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HealthyEating.Models.BioData", b =>
                {
                    b.HasOne("HealthyEating.Models.ApplicationUser", "Users")
                        .WithOne("BioDatas")
                        .HasForeignKey("HealthyEating.Models.BioData", "UsersId");
                });

            modelBuilder.Entity("HealthyEating.Models.Menu", b =>
                {
                    b.HasOne("HealthyEating.Models.ApplicationUser", "Users")
                        .WithMany("Menus")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("HealthyEating.Models.MenuChoice", b =>
                {
                    b.HasOne("HealthyEating.Models.Menu", "Menus")
                        .WithMany("MenuChoices")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyEating.Models.Recipe", "Recipes")
                        .WithMany("MenuChoices")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyEating.Models.Recipe", b =>
                {
                    b.HasOne("HealthyEating.Models.ApplicationUser", "Users")
                        .WithMany("Recipes")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("HealthyEating.Models.RecipeIngredient", b =>
                {
                    b.HasOne("HealthyEating.Models.Ingredient", "Ingredients")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyEating.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyEating.Models.RecipeRating", b =>
                {
                    b.HasOne("HealthyEating.Models.Recipe", "Recipes")
                        .WithMany("RecipeRatings")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyEating.Models.ApplicationUser", "Users")
                        .WithMany("RecipeRatings")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HealthyEating.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HealthyEating.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyEating.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HealthyEating.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
