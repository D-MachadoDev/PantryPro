using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Recipes
{
    public class CreateRecipeIngredientDto
    {
        [Required]
        public int IngredientId { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Quantity { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Unit { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Notes { get; set; }
        
        public bool IsOptional { get; set; }
        public int SortOrder { get; set; }
    }
}