using Mealplan.Models;
using Mealplan.Models.CustomViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mealplan.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Biodata> Biodata { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Reciperatning> Reciperatning { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_Aspnetroleclaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            builder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            builder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            builder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            builder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_Aspnetuserroles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            builder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            builder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("aspnetusertokens");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            builder.Entity<Biodata>(entity =>
            {
                entity.HasKey(e => e.BioId);

                entity.ToTable("biodata");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_BioData_UserId");

                entity.Property(e => e.BioId).HasColumnType("int(11)");

                entity.Property(e => e.ActivityLevel).HasColumnType("tinyint(4)");

                entity.Property(e => e.Height).HasColumnType("tinyint(4)");

                entity.Property(e => e.Weight).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Biodata)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BioData_Aspnetusers_UserId");
            });

            builder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(95);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            builder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipe");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_Recipe_UserId");

                entity.Property(e => e.RecipeId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Recipe_Aspnetusers_UserId");
            });

            builder.Entity<Reciperatning>(entity =>
            {
                entity.HasKey(e => e.RecipeId);

                entity.ToTable("reciperatning");

                entity.Property(e => e.RecipeId).HasColumnType("int(11)");

                entity.Property(e => e.RecipeRating).HasColumnType("smallint(6)");

                entity.HasOne(d => d.Recipe)
                    .WithOne(p => p.Reciperatning)
                    .HasForeignKey<Reciperatning>(d => d.RecipeId)
                    .HasConstraintName("FK_RecipeRatning_Recipe_RecipeId");
            });


        }
    }
}
