using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.MealPlans
{
    public class CreateMealPlanRecipeDto
    {
        [Required]
        public int RecipeId { get; set; }
        
        [Required]
        public DateTime ScheduledDate { get; set; }
        
        [Required]
        [StringLength(50)]
        public string MealType { get; set; } = string.Empty;
        
        [Range(1, 20)]
        public int ServingSize { get; set; } = 4;
        
        [StringLength(500)]
        public string? Notes { get; set; }
    }
}