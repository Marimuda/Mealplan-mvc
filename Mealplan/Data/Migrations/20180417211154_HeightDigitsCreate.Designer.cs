﻿// <auto-generated />
using Mealplan.Data;
using Mealplan.Models.CustomViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Mealplan.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180417211154_HeightDigitsCreate")]
    partial class HeightDigitsCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Mealplan.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetroleclaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .HasName("IX_Aspnetroleclaims_RoleId");

                    b.ToTable("aspnetroleclaims");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetroles", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("aspnetroles");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetuserclaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IX_AspNetUserClaims_UserId");

                    b.ToTable("aspnetuserclaims");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetuserlogins", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId")
                        .HasName("IX_AspNetUserLogins_UserId");

                    b.ToTable("aspnetuserlogins");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetuserroles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId")
                        .HasName("IX_Aspnetuserroles_RoleId");

                    b.ToTable("aspnetuserroles");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetusers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int(11)");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit(1)");

                    b.Property<DateTime?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit(1)");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("aspnetusers");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetusertokens", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("aspnetusertokens");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Biodata", b =>
                {
                    b.Property<int>("BioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("ActivityLevel")
                        .HasColumnType("tinyint(4)");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Gender");

                    b.Property<int>("Height")
                        .HasColumnType("tinyint(4)");

                    b.Property<string>("UserId");

                    b.Property<int>("Weight")
                        .HasColumnType("tinyint(4)");

                    b.HasKey("BioId");

                    b.HasIndex("UserId")
                        .HasName("IX_BioData_UserId");

                    b.ToTable("biodata");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(95);

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("MigrationId");

                    b.ToTable("__efmigrationshistory");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("ReCreationDate");

                    b.Property<string>("RecipeDescription");

                    b.Property<string>("RecipeName");

                    b.Property<string>("UserId");

                    b.HasKey("RecipeId");

                    b.HasIndex("UserId")
                        .HasName("IX_Recipe_UserId");

                    b.ToTable("recipe");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Reciperatning", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int(11)");

                    b.Property<short>("RecipeRating")
                        .HasColumnType("smallint(6)");

                    b.HasKey("RecipeId");

                    b.ToTable("reciperatning");
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

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetroleclaims", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetroles", "Role")
                        .WithMany("Aspnetroleclaims")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetuserclaims", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetusers", "User")
                        .WithMany("Aspnetuserclaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetuserlogins", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetusers", "User")
                        .WithMany("Aspnetuserlogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetuserroles", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetroles", "Role")
                        .WithMany("Aspnetuserroles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetusers", "User")
                        .WithMany("Aspnetuserroles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Aspnetusertokens", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetusers", "User")
                        .WithMany("Aspnetusertokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Biodata", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetusers", "User")
                        .WithMany("Biodata")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_BioData_Aspnetusers_UserId");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Recipe", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Aspnetusers", "User")
                        .WithMany("Recipe")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Recipe_Aspnetusers_UserId");
                });

            modelBuilder.Entity("Mealplan.Models.CustomViewModels.Reciperatning", b =>
                {
                    b.HasOne("Mealplan.Models.CustomViewModels.Recipe", "Recipe")
                        .WithMany("Reciperatnings")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK_RecipeRatning_Recipe_RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("Mealplan.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Mealplan.Models.ApplicationUser")
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

                    b.HasOne("Mealplan.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Mealplan.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
