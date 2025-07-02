using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Recipes
{
    public class CreateRecipeStepDto
    {
        [Required]
        public int StepNumber { get; set; }
        
        [Required]
        [StringLength(2000)]
        public string Instructions { get; set; } = string.Empty;
        
        [Range(0, 1440)]
        public int? TimeMinutes { get; set; }
        
        [StringLength(500)]
        public string? Tips { get; set; }
    }
}