using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Shopping
{
    public class CreateShoppingListItemDto
    {
        [Required]
        public int IngredientId { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Quantity { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Unit { get; set; } = string.Empty;
        
        [Range(0, double.MaxValue)]
        public decimal? EstimatedPrice { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public int SortOrder { get; set; }
    }
}