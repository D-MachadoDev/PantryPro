using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.MealPlans
{
    public class MealPlanDto : BaseDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? TotalCalories { get; set; }

        // Relaciones
        public List<MealPlanRecipeDto> MealPlanRecipes { get; set; } = new();

        // Propiedades calculadas
        public int TotalDays { get; set; }
        public int CompletedMeals { get; set; }
        public int TotalMeals { get; set; }
        public decimal CompletionPercentage { get; set; }
        public List<string> RequiredIngredients { get; set; } = new();
        public List<string> MissingIngredients { get; set; } = new();
    }
}