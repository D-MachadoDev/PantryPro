using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Inventory;

namespace PantryPro.Core.Models.Recipes
{
    public class RecipeIngredient : BaseEntity
    {
        [Required]
        public int RecipeId { get; set; }
        
        [Required]
        public int IngredientId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Unit { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Notes { get; set; } // "diced", "optional", etc.
        
        public bool IsOptional { get; set; } = false;
        
        public int SortOrder { get; set; } = 0;
        
        // Relationships
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; } = null!;
        
        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}