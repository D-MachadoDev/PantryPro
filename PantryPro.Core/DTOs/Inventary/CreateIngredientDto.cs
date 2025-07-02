using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Inventary
{
    public class CreateIngredientDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string DefaultUnit { get; set; } = string.Empty;
        
        // Información nutricional opcional
        public decimal? CaloriesPer100g { get; set; }
        public decimal? ProteinPer100g { get; set; }
        public decimal? CarbsPer100g { get; set; }
        public decimal? FatPer100g { get; set; }
        public decimal? FiberPer100g { get; set; }
        public decimal? SugarPer100g { get; set; }
        public decimal? SodiumPer100g { get; set; }
        public int? AverageShelfLifeDays { get; set; }
    }
}