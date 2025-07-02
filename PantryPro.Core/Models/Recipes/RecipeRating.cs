using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Users;

namespace PantryPro.Core.Models.Recipes
{
    public class RecipeRating : BaseEntity
    {
        [Required]
        public int RecipeId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        
        [StringLength(1000)]
        public string? Comment { get; set; }
        
        // Relaciones
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; } = null!;
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
    }
}