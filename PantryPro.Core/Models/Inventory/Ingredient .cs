using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Recipes;

namespace PantryPro.Core.Models.Inventory
{
    public class Ingredient : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        [StringLength(50)]
        public string DefaultUnit { get; set; } = "unidad"; // grams, liters, units, etc.
        
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        
        // Nutritional information (per 100g/ml)
        public decimal? CaloriesPer100g { get; set; }
        public decimal? ProteinPer100g { get; set; }
        public decimal? CarbsPer100g { get; set; }
        public decimal? FatPer100g { get; set; }
        public decimal? FiberPer100g { get; set; }
        public decimal? SugarPer100g { get; set; }
        public decimal? SodiumPer100g { get; set; }
        
        // Average shelf life in days
        public int? AverageShelfLifeDays { get; set; }
        
        // Relationships
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<UserIngredient> UserIngredients { get; set; } = new List<UserIngredient>();
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}