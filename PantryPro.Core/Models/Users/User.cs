using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Achievements;
using PantryPro.Core.Models.Inventory;
using PantryPro.Core.Models.MealPlans;
using PantryPro.Core.Models.Recipes;
using PantryPro.Core.Models.Shopping;
using PantryPro.Core.Models.Subscriptions;

namespace PantryPro.Core.Models.Users
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        [StringLength(500)]
        public string? Bio { get; set; }
        
        [StringLength(255)]
        public string? ProfileImageUrl { get; set; }
        
        public bool EmailVerified { get; set; } = false;
        
        public DateTime? LastLoginAt { get; set; }
        
        // Configuraciones de usuario
        public bool NotificationsEnabled { get; set; } = true;
        public bool ExpirationAlertsEnabled { get; set; } = true;
        public int ExpirationAlertDays { get; set; } = 3;
        
        // Relaciones
        public virtual ICollection<UserIngredient> UserIngredients { get; set; } = new List<UserIngredient>();
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public virtual ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
        public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
        public virtual UserPreference? UserPreference { get; set; }
        public virtual UserSubscription? UserSubscription { get; set; }
    }
}