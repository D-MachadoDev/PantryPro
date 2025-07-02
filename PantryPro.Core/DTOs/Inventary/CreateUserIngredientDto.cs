using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Inventary
{
    public class CreateUserIngredientDto
    {
        [Required]
        public int IngredientId { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Quantity { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Unit { get; set; } = string.Empty;
        
        public DateTime? ExpirationDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0")]
        public decimal? PurchasePrice { get; set; }
        
        [StringLength(100)]
        public string? Location { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
    }
}