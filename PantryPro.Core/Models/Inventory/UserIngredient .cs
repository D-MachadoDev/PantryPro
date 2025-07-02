using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Users;

namespace PantryPro.Core.Models.Inventory
{
    public class UserIngredient : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int IngredientId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Unit { get; set; } = string.Empty;
        
        public DateTime? ExpirationDate { get; set; }
        
        public DateTime? PurchaseDate { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? PurchasePrice { get; set; }
        
        [StringLength(100)]
        public string? Location { get; set; } // "Refrigerator", "Pantry", etc.
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public bool IsConsumed { get; set; } = false;
        public DateTime? ConsumedAt { get; set; }
        
        // Relationships
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}