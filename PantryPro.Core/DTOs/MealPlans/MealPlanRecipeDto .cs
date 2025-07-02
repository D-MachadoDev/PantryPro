using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.MealPlans
{
    public class MealPlanRecipeDto : BaseDto
    {
        public int MealPlanId { get; set; }
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; } = string.Empty;
        public string? RecipeImageUrl { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string MealType { get; set; } = string.Empty;
        public int ServingSize { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Notes { get; set; }
        
        // Información de la receta
        public int PreparationTimeMinutes { get; set; }
        public int CookingTimeMinutes { get; set; }
        public decimal? CaloriesPerServing { get; set; }
        public string Difficulty { get; set; } = string.Empty;
    }
}