using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Subscriptions
{
    public class UserSubscriptionDto : BaseDto
    {
        public int UserId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public decimal PlanPrice { get; set; }
        public string BillingPeriod { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? StripeSubscriptionId { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime? TrialEndsAt { get; set; }
        
        // Propiedades calculadas
        public bool IsActive { get; set; }
        public bool IsTrialing { get; set; }
        public int? DaysRemaining { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public bool CanUpgrade { get; set; }
        public bool CanDowngrade { get; set; }
    }
}