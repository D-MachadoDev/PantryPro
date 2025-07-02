using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Subscriptions
{
    public class SubscriptionPlanDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string BillingPeriod { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new();
        public int MaxRecipes { get; set; }
        public int MaxMealPlans { get; set; }
        public bool HasAIRecommendations { get; set; }
        public bool HasAdvancedAnalytics { get; set; }
        public bool HasExportFeatures { get; set; }
        public bool IsActive { get; set; }

        // Para mostrar en UI
        public bool IsPopular { get; set; }
        public string? Badge { get; set; }
        public decimal? DiscountPercentage { get; set; }
    }
}