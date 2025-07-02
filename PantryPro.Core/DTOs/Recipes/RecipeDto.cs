using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Recipes
{
    public class RecipeDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int ServingSize { get; set; }
        public int PreparationTimeMinutes { get; set; }
        public int CookingTimeMinutes { get; set; }
        public int TotalTimeMinutes { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        
        // Información nutricional
        public decimal? CaloriesPerServing { get; set; }
        public decimal? ProteinPerServing { get; set; }
        public decimal? CarbsPerServing { get; set; }
        public decimal? FatPerServing { get; set; }
        
        // Etiquetas dietéticas
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsKeto { get; set; }
        public bool IsPaleo { get; set; }
        
        public List<string> Tags { get; set; } = new();
        public string? CuisineType { get; set; }
        public string? MealType { get; set; }
        
        // Estadísticas
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public int CookCount { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFeatured { get; set; }
        
        // Relaciones
        public List<RecipeIngredientDto> Ingredients { get; set; } = new();
        public List<RecipeStepDto> Steps { get; set; } = new();
        public decimal? AverageRating { get; set; }
        public int RatingCount { get; set; }
        
        // Propiedades calculadas
        public bool CanMakeWithAvailableIngredients { get; set; }
        public List<string> MissingIngredients { get; set; } = new();
        public decimal? EstimatedCost { get; set; }
    }
}