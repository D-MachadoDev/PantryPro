using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Recipes
{
    public class CreateRecipeDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [Required]
        [Range(1, 20)]
        public int ServingSize { get; set; } = 4;
        
        [Required]
        [Range(0, 1440)]
        public int PreparationTimeMinutes { get; set; }
        
        [Required]
        [Range(0, 1440)]
        public int CookingTimeMinutes { get; set; }
        
        [Required]
        public int Difficulty { get; set; } = 2; // RecipeDifficulty enum
        
        // Etiquetas dietéticas
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsKeto { get; set; }
        public bool IsPaleo { get; set; }
        
        public List<string> Tags { get; set; } = new();
        
        [StringLength(100)]
        public string? CuisineType { get; set; }
        
        [StringLength(100)]
        public string? MealType { get; set; }
        
        public bool IsPublic { get; set; } = false;
        
        // Ingredientes y pasos
        [Required]
        public List<CreateRecipeIngredientDto> Ingredients { get; set; } = new();
        
        [Required]
        public List<CreateRecipeStepDto> Steps { get; set; } = new();
    }
}