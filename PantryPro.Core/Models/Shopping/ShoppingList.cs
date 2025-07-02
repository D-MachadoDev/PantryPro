using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.MealPlans;
using PantryPro.Core.Models.Users;

namespace PantryPro.Core.Models.Shopping
{
public class ShoppingList : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        
        public int? MealPlanId { get; set; } // Opcional, puede ser manual
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public DateTime? ShoppingDate { get; set; }
        
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? TotalBudget { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? ActualCost { get; set; }
        
        // Relaciones
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("MealPlanId")]
        public virtual MealPlan? MealPlan { get; set; }
        
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
    }
}