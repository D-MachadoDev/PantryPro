using Microsoft.EntityFrameworkCore;
using PantryPro.Core.Enums;
using PantryPro.Core.Models;
using PantryPro.Core.Models.Achievements;
using PantryPro.Core.Models.Inventory;
using PantryPro.Core.Models.MealPlans;
using PantryPro.Core.Models.Recipes;
using PantryPro.Core.Models.Shopping;
using PantryPro.Core.Models.Subscriptions;
using PantryPro.Core.Models.Users;

namespace PantryPro.Infrastructure.Data
{
    public class PantryProDbContext : DbContext
    {
        public PantryProDbContext(DbContextOptions<PantryProDbContext> options) : base(options)
        {
        }

        // ============================================================================
        // DBSETS - TABLE DEFINITIONS
        // ============================================================================

        // Users and Authentication
        public DbSet<User> Users { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }

        // Inventory
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<UserIngredient> UserIngredients { get; set; }

        // Recipes
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }

        // Meal Planning
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<MealPlanRecipe> MealPlanRecipes { get; set; }

        // Shopping List
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

        // Gamification
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }

        // Subscriptions
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================================================================
            // USERS AND AUTHENTICATION CONFIGURATION
            // ============================================================================

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Bio).HasMaxLength(500);
                entity.Property(e => e.ProfileImageUrl).HasMaxLength(255);
                
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.EmailVerified).HasDefaultValue(false);
                entity.Property(e => e.NotificationsEnabled).HasDefaultValue(true);
                entity.Property(e => e.ExpirationAlertsEnabled).HasDefaultValue(true);
                entity.Property(e => e.ExpirationAlertDays).HasDefaultValue(3);
            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.ToTable("UserPreferences");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.UserId).IsUnique();
                entity.Property(e => e.UserId).IsRequired();
                
                entity.Property(e => e.Allergies).HasMaxLength(1000);
                entity.Property(e => e.DislikedIngredients).HasMaxLength(1000);
                entity.Property(e => e.MaxCookingTimeMinutes).HasDefaultValue(60);
                entity.Property(e => e.PreferredCuisineTypes).IsRequired();
                entity.Property(e => e.PreferredServingSize).HasDefaultValue(4);
                
                // One-to-one relationship with User
                entity.HasOne(e => e.User)
                      .WithOne(u => u.UserPreference)
                      .HasForeignKey<UserPreference>(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ============================================================================
            // INVENTORY CONFIGURATION
            // ============================================================================

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Color).HasMaxLength(50);
                entity.Property(e => e.Icon).HasMaxLength(50);
                entity.Property(e => e.SortOrder).HasDefaultValue(0);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredients");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.Name, e.CategoryId }).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CategoryId).IsRequired();
                entity.Property(e => e.DefaultUnit).IsRequired().HasMaxLength(50).HasDefaultValue("unidad");
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                
                // Nutritional properties configuration
                entity.Property(e => e.CaloriesPer100g).HasColumnType("decimal(8,2)");
                entity.Property(e => e.ProteinPer100g).HasColumnType("decimal(8,2)");
                entity.Property(e => e.CarbsPer100g).HasColumnType("decimal(8,2)");
                entity.Property(e => e.FatPer100g).HasColumnType("decimal(8,2)");
                entity.Property(e => e.FiberPer100g).HasColumnType("decimal(8,2)");
                entity.Property(e => e.SugarPer100g).HasColumnType("decimal(8,2)");
                entity.Property(e => e.SodiumPer100g).HasColumnType("decimal(8,2)");
                
                // Relationship with Category
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Ingredients)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserIngredient>(entity =>
            {
                entity.ToTable("UserIngredients");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.UserId, e.IngredientId, e.ExpirationDate });
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.IngredientId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(e => e.Unit).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Location).HasMaxLength(100);
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.IsConsumed).HasDefaultValue(false);
                
                // Relationships
                entity.HasOne(e => e.User)
                      .WithMany(u => u.UserIngredients)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.Ingredient)
                      .WithMany(i => i.UserIngredients)
                      .HasForeignKey(e => e.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================================================
            // RECIPES CONFIGURATION
            // ============================================================================

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipes");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.Title);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.IsPublic);
                
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.ServingSize).IsRequired().HasDefaultValue(4);
                entity.Property(e => e.PreparationTimeMinutes).IsRequired();
                entity.Property(e => e.CookingTimeMinutes).IsRequired();
                entity.Property(e => e.Difficulty).IsRequired().HasDefaultValue(RecipeDifficulty.Medium);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                
                // Nutritional properties
                entity.Property(e => e.CaloriesPerServing).HasColumnType("decimal(8,2)");
                entity.Property(e => e.ProteinPerServing).HasColumnType("decimal(8,2)");
                entity.Property(e => e.CarbsPerServing).HasColumnType("decimal(8,2)");
                entity.Property(e => e.FatPerServing).HasColumnType("decimal(8,2)");
                
                entity.Property(e => e.Tags).HasMaxLength(500);
                entity.Property(e => e.CuisineType).HasMaxLength(100);
                entity.Property(e => e.MealType).HasMaxLength(100);
                
                // Statistics
                entity.Property(e => e.ViewCount).HasDefaultValue(0);
                entity.Property(e => e.LikeCount).HasDefaultValue(0);
                entity.Property(e => e.CookCount).HasDefaultValue(0);
                entity.Property(e => e.IsPublic).HasDefaultValue(false);
                entity.Property(e => e.IsFeatured).HasDefaultValue(false);
                
                // Calculated property
                entity.Ignore(e => e.TotalTimeMinutes);
                
                // Relationship with User
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Recipes)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("RecipeIngredients");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.RecipeId, e.IngredientId }).IsUnique();
                entity.Property(e => e.RecipeId).IsRequired();
                entity.Property(e => e.IngredientId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(e => e.Unit).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(200);
                entity.Property(e => e.IsOptional).HasDefaultValue(false);
                entity.Property(e => e.SortOrder).HasDefaultValue(0);
                
                // Relationships
                entity.HasOne(e => e.Recipe)
                      .WithMany(r => r.RecipeIngredients)
                      .HasForeignKey(e => e.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.Ingredient)
                      .WithMany(i => i.RecipeIngredients)
                      .HasForeignKey(e => e.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RecipeStep>(entity =>
            {
                entity.ToTable("RecipeSteps");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.RecipeId, e.StepNumber }).IsUnique();
                entity.Property(e => e.RecipeId).IsRequired();
                entity.Property(e => e.StepNumber).IsRequired();
                entity.Property(e => e.Instructions).IsRequired().HasMaxLength(2000);
                entity.Property(e => e.Tips).HasMaxLength(500);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                
                // Relationship with Recipe
                entity.HasOne(e => e.Recipe)
                      .WithMany(r => r.RecipeSteps)
                      .HasForeignKey(e => e.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RecipeRating>(entity =>
            {
                entity.ToTable("RecipeRatings");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.RecipeId, e.UserId }).IsUnique();
                entity.Property(e => e.RecipeId).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.Rating).IsRequired();
                entity.Property(e => e.Comment).HasMaxLength(1000);
                
                // Relationships
                entity.HasOne(e => e.Recipe)
                      .WithMany(r => r.RecipeRatings)
                      .HasForeignKey(e => e.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================================================
            // MEAL PLANNING CONFIGURATION
            // ============================================================================

            modelBuilder.Entity<MealPlan>(entity =>
            {
                entity.ToTable("MealPlans");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.UserId);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.EstimatedCost).HasColumnType("decimal(10,2)");
                entity.Property(e => e.TotalCalories).HasColumnType("decimal(8,2)");
                
                // Relationship with User
                entity.HasOne(e => e.User)
                      .WithMany(u => u.MealPlans)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MealPlanRecipe>(entity =>
            {
                entity.ToTable("MealPlanRecipes");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.MealPlanId, e.ScheduledDate, e.MealType });
                entity.Property(e => e.MealPlanId).IsRequired();
                entity.Property(e => e.RecipeId).IsRequired();
                entity.Property(e => e.ScheduledDate).IsRequired();
                entity.Property(e => e.MealType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ServingSize).HasDefaultValue(4);
                entity.Property(e => e.IsCompleted).HasDefaultValue(false);
                entity.Property(e => e.Notes).HasMaxLength(500);
                
                // Relationships
                entity.HasOne(e => e.MealPlan)
                      .WithMany(mp => mp.MealPlanRecipes)
                      .HasForeignKey(e => e.MealPlanId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.Recipe)
                      .WithMany(r => r.MealPlanRecipes)
                      .HasForeignKey(e => e.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================================================
            // SHOPPING LIST CONFIGURATION
            // ============================================================================

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.ToTable("ShoppingLists");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.UserId);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.IsCompleted).HasDefaultValue(false);
                entity.Property(e => e.TotalBudget).HasColumnType("decimal(10,2)");
                entity.Property(e => e.ActualCost).HasColumnType("decimal(10,2)");
                
                // Relationships
                entity.HasOne(e => e.User)
                      .WithMany(u => u.ShoppingLists)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.MealPlan)
                      .WithMany(mp => mp.ShoppingLists)
                      .HasForeignKey(e => e.MealPlanId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ShoppingListItem>(entity =>
            {
                entity.ToTable("ShoppingListItems");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.ShoppingListId, e.IngredientId });
                entity.Property(e => e.ShoppingListId).IsRequired();
                entity.Property(e => e.IngredientId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(e => e.Unit).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EstimatedPrice).HasColumnType("decimal(10,2)");
                entity.Property(e => e.ActualPrice).HasColumnType("decimal(10,2)");
                entity.Property(e => e.IsPurchased).HasDefaultValue(false);
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.SortOrder).HasDefaultValue(0);
                
                // Relationships
                entity.HasOne(e => e.ShoppingList)
                      .WithMany(sl => sl.ShoppingListItems)
                      .HasForeignKey(e => e.ShoppingListId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.Ingredient)
                      .WithMany()
                      .HasForeignKey(e => e.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================================================
            // GAMIFICATION CONFIGURATION
            // ============================================================================

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("Achievements");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                entity.Property(e => e.BadgeColor).HasMaxLength(50);
                entity.Property(e => e.Points).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Requirements).HasMaxLength(500);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            modelBuilder.Entity<UserAchievement>(entity =>
            {
                entity.ToTable("UserAchievements");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => new { e.UserId, e.AchievementId }).IsUnique();
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.AchievementId).IsRequired();
                entity.Property(e => e.EarnedAt).IsRequired();
                
                // Relationships
                entity.HasOne(e => e.User)
                      .WithMany(u => u.UserAchievements)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.Achievement)
                      .WithMany(a => a.UserAchievements)
                      .HasForeignKey(e => e.AchievementId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================================================
            // SUBSCRIPTIONS CONFIGURATION
            // ============================================================================

            modelBuilder.Entity<SubscriptionPlan>(entity =>
            {
                entity.ToTable("SubscriptionPlans");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(e => e.BillingPeriod).IsRequired().HasMaxLength(20).HasDefaultValue("monthly");
                entity.Property(e => e.Features).HasMaxLength(1000);
                entity.Property(e => e.MaxRecipes).HasDefaultValue(100);
                entity.Property(e => e.MaxMealPlans).HasDefaultValue(10);
                entity.Property(e => e.HasAIRecommendations).HasDefaultValue(false);
                entity.Property(e => e.HasAdvancedAnalytics).HasDefaultValue(false);
                entity.Property(e => e.HasExportFeatures).HasDefaultValue(false);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            modelBuilder.Entity<UserSubscription>(entity =>
            {
                entity.ToTable("UserSubscriptions");
                entity.HasKey(e => e.Id);
                
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.StripeSubscriptionId).IsUnique();
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.SubscriptionPlanId).IsRequired();
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasDefaultValue(SubscriptionStatus.Active);
                entity.Property(e => e.StripeSubscriptionId).HasMaxLength(100);
                entity.Property(e => e.StripeCustomerId).HasMaxLength(100);
                
                // Relationships
                entity.HasOne(e => e.User)
                      .WithOne(u => u.UserSubscription)
                      .HasForeignKey<UserSubscription>(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.SubscriptionPlan)
                      .WithMany(sp => sp.UserSubscriptions)
                      .HasForeignKey(e => e.SubscriptionPlanId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================================================
            // AUTOMATIC AUDIT CONFIGURATION
            // ============================================================================
            
            // Configure automatic update of UpdatedAt for all BaseEntity entities
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.CreatedAt))
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                }
            }
        }

        // ============================================================================
        // OVERRIDE FOR AUTOMATIC AUDIT
        // ============================================================================

        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.IsActive = true;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }
        }

    }
}