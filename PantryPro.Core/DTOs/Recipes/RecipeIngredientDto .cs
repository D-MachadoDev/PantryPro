using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Recipes
{
    public class RecipeIngredientDto : BaseDto
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public bool IsOptional { get; set; }
        public int SortOrder { get; set; }
        
        // Propiedades calculadas
        public bool IsAvailable { get; set; }
        public decimal? AvailableQuantity { get; set; }
        public decimal? EstimatedPrice { get; set; }
    }
}