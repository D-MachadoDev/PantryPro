using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.ViewModels.Ingredients
{
    public class CreateIngredientDto
    {
        [Required] public string Name { get; set; }          // "Tomate"
        [Required] public double Quantity { get; set; }      // 1.5
        public string? Unit { get; set; }                     // "kg"
        public int Category { get; set; }                    // 2
        public DateTime? ExpirationDate { get; set; }        // 2025‑07‑10
    }
}