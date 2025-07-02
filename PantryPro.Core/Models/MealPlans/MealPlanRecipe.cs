using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Recipes;

namespace PantryPro.Core.Models.MealPlans
{
    public class MealPlanRecipe : BaseEntity
    {
        [Required]
        public int MealPlanId { get; set; }
        
        [Required]
        public int RecipeId { get; set; }
        
        [Required]
        public DateTime ScheduledDate { get; set; }
        
        [Required]
        [StringLength(50)]
        public string MealType { get; set; } = string.Empty; // "Desayuno", "Almuerzo", "Cena", "Snack"
        
        public int ServingSize { get; set; } = 4;
        
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        // Relaciones
        [ForeignKey("MealPlanId")]
        public virtual MealPlan MealPlan { get; set; } = null!;
        
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; } = null!;
    }
}