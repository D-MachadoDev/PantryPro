using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Inventary
{
    public class UserIngredientDto : BaseDto
    {
        public int UserId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string? IngredientImageUrl { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public bool IsConsumed { get; set; }
        public DateTime? ConsumedAt { get; set; }
        
        // Propiedades calculadas
        public int DaysUntilExpiration { get; set; }
        public bool IsExpired { get; set; }
        public bool IsExpiringSoon { get; set; }
        public string ExpirationStatus { get; set; } = string.Empty; // "Fresh", "Expiring", "Expired"
    }
}