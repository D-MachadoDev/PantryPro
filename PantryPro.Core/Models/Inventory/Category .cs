using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.Models.Inventory
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(50)]
        public string? Color { get; set; } // For UI (hex color)
        
        [StringLength(50)]
        public string? Icon { get; set; } // Icon name
        
        public int SortOrder { get; set; } = 0;
        
        // Relationships
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

}