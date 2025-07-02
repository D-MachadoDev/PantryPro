using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Shopping
{
    public class ShoppingListDto : BaseDto
    {
        public int UserId { get; set; }
        public int? MealPlanId { get; set; }
        public string? MealPlanName { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? ShoppingDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public decimal? TotalBudget { get; set; }
        public decimal? ActualCost { get; set; }
        
        // Relaciones
        public List<ShoppingListItemDto> Items { get; set; } = new();
        
        // Propiedades calculadas
        public int TotalItems { get; set; }
        public int PurchasedItems { get; set; }
        public decimal CompletionPercentage { get; set; }
        public decimal? EstimatedTotal { get; set; }
        public decimal? BudgetVariance { get; set; }
    }
}