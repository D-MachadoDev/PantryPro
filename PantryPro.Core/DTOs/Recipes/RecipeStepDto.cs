using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Recipes
{
    public class RecipeStepDto : BaseDto
    {
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Instructions { get; set; } = string.Empty;
        public int? TimeMinutes { get; set; }
        public string? Tips { get; set; }
        public string? ImageUrl { get; set; }
    }
}