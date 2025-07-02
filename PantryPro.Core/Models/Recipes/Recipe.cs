using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Enums;
using PantryPro.Core.Models.MealPlans;
using PantryPro.Core.Models.Users;

namespace PantryPro.Core.Models.Recipes
{
    public class Recipe : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [Required]
        public int UserId { get; set; } // Creador de la receta
        
        [Required]
        public int ServingSize { get; set; } = 4;
        
        [Required]
        public int PreparationTimeMinutes { get; set; }
        
        [Required]
        public int CookingTimeMinutes { get; set; }
        
        public int TotalTimeMinutes => PreparationTimeMinutes + CookingTimeMinutes;
        
        [Required]
        public RecipeDifficulty Difficulty { get; set; } = RecipeDifficulty.Medium;
        
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        
        // Información nutricional calculada
        [Column(TypeName = "decimal(8,2)")]
        public decimal? CaloriesPerServing { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? ProteinPerServing { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? CarbsPerServing { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? FatPerServing { get; set; }
        
        // Etiquetas y categorización
        public bool IsVegetarian { get; set; } = false;
        public bool IsVegan { get; set; } = false;
        public bool IsGlutenFree { get; set; } = false;
        public bool IsDairyFree { get; set; } = false;
        public bool IsKeto { get; set; } = false;
        public bool IsPaleo { get; set; } = false;
        
        [StringLength(500)]
        public string? Tags { get; set; } // JSON array: ["quick", "healthy", "budget-friendly"]
        
        [StringLength(100)]
        public string? CuisineType { get; set; } // "Mexican", "Italian", etc.
        
        [StringLength(100)]
        public string? MealType { get; set; } // "Desayuno", "Almuerzo", "Cena", "Snack"
        
        // Estadísticas
        public int ViewCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public int CookCount { get; set; } = 0; // Veces que se ha cocinado
        
        public bool IsPublic { get; set; } = false;
        public bool IsFeatured { get; set; } = false;
        
        // Relaciones
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
        public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new List<RecipeRating>();
        public virtual ICollection<MealPlanRecipe> MealPlanRecipes { get; set; } = new List<MealPlanRecipe>();
    }
}