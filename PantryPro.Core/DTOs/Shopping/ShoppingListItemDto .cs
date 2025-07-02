using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Shopping
{
    public class ShoppingListItemDto : BaseDto
    {
        public int ShoppingListId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal? EstimatedPrice { get; set; }
        public decimal? ActualPrice { get; set; }
        public bool IsPurchased { get; set; }
        public DateTime? PurchasedAt { get; set; }
        public string? Notes { get; set; }
        public int SortOrder { get; set; }
        
        // Propiedades calculadas
        public decimal? PriceVariance { get; set; }
        public bool IsOverBudget { get; set; }
    }
}