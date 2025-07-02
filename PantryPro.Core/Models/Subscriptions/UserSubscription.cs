using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Enums;
using PantryPro.Core.Models.Users;

namespace PantryPro.Core.Models.Subscriptions
{
    public class UserSubscription : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int SubscriptionPlanId { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        [Required]
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;
        
        [StringLength(100)]
        public string? StripeSubscriptionId { get; set; }
        
        [StringLength(100)]
        public string? StripeCustomerId { get; set; }
        
        public DateTime? CancelledAt { get; set; }
        public DateTime? TrialEndsAt { get; set; }
        
        // Relaciones
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("SubscriptionPlanId")]
        public virtual SubscriptionPlan SubscriptionPlan { get; set; } = null!;
    }
}
