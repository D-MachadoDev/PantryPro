using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.Models.Users
{
  public class UserPreference : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        
        // Preferencias dietéticas
        public bool IsVegetarian { get; set; } = false;
        public bool IsVegan { get; set; } = false;
        public bool IsGlutenFree { get; set; } = false;
        public bool IsDairyFree { get; set; } = false;
        public bool IsKeto { get; set; } = false;
        public bool IsPaleo { get; set; } = false;
        
        // Alergias (JSON array)
        [StringLength(1000)]
        public string? Allergies { get; set; } // ["nuts", "shellfish", "eggs"]
        
        // Ingredientes que no le gustan
        [StringLength(1000)]
        public string? DislikedIngredients { get; set; } // ["cilantro", "mushrooms"]
        
        // Preferencias de cocina
        public int MaxCookingTimeMinutes { get; set; } = 60;
        public string PreferredCuisineTypes { get; set; } = string.Empty; // ["mexican", "italian", "asian"]
        public int PreferredServingSize { get; set; } = 4;
        
        // Objetivos nutricionales
        public int? DailyCalorieGoal { get; set; }
        public int? DailyProteinGoal { get; set; }
        public int? DailyCarbGoal { get; set; }
        public int? DailyFatGoal { get; set; }
        
        // Relaciones
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
    }
}