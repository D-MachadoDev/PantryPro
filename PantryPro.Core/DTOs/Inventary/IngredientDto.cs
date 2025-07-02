using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Inventary
{
    public class IngredientDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string DefaultUnit { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        
        // Información nutricional
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