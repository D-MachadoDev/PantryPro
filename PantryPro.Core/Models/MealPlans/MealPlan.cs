using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Shopping;
using PantryPro.Core.Models.Users;

namespace PantryPro.Core.Models.MealPlans
{
    public class MealPlan : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        public new bool IsActive { get; set; } = true;
        
        // Estadísticas
        [Column(TypeName = "decimal(10,2)")]
        public decimal? EstimatedCost { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? TotalCalories { get; set; }
        
        // Relaciones
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        public virtual ICollection<MealPlanRecipe> MealPlanRecipes { get; set; } = new List<MealPlanRecipe>();
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
    }
}