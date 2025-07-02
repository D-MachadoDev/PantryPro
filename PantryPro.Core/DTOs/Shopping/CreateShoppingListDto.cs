using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Shopping
{
    public class CreateShoppingListDto
    {
        public int? MealPlanId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public DateTime? ShoppingDate { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal? TotalBudget { get; set; }
        
        public List<CreateShoppingListItemDto> Items { get; set; } = new();
    }
}