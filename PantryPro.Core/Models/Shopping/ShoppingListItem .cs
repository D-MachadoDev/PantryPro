using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Inventory;

namespace PantryPro.Core.Models.Shopping
{
    public class ShoppingListItem : BaseEntity
    {
        [Required]
        public int ShoppingListId { get; set; }
        
        [Required]
        public int IngredientId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Unit { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? EstimatedPrice { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? ActualPrice { get; set; }
        
        public bool IsPurchased { get; set; } = false;
        public DateTime? PurchasedAt { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public int SortOrder { get; set; } = 0;
        
        // Relaciones
        [ForeignKey("ShoppingListId")]
        public virtual ShoppingList ShoppingList { get; set; } = null!;
        
        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}