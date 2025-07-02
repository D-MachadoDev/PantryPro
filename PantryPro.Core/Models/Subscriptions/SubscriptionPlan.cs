using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.Models.Subscriptions
{
    public class SubscriptionPlan : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [Required]
        [StringLength(20)]
        public string BillingPeriod { get; set; } = "monthly"; // monthly, yearly
        
        [StringLength(1000)]
        public string? Features { get; set; } // JSON array de características
        
        public int MaxRecipes { get; set; } = 100;
        public int MaxMealPlans { get; set; } = 10;
        public bool HasAIRecommendations { get; set; } = false;
        public bool HasAdvancedAnalytics { get; set; } = false;
        public bool HasExportFeatures { get; set; } = false;
        
        public bool IsActive { get; set; } = true;
        
        // Relaciones
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
    }
}