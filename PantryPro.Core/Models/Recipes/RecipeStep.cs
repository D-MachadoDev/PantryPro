using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.Models.Recipes
{
    public class RecipeStep : BaseEntity
    {
        [Required]
        public int RecipeId { get; set; }
        
        [Required]
        public int StepNumber { get; set; }
        
        [Required]
        [StringLength(2000)]
        public string Instructions { get; set; } = string.Empty;
        
        public int? TimeMinutes { get; set; } // Tiempo estimado para este paso
        
        [StringLength(500)]
        public string? Tips { get; set; }
        
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        
        // Relaciones
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; } = null!;
    }
}