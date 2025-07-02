using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Search
{
    public class IngredientSearchDto
    {
        public string? Query { get; set; }
        public int? CategoryId { get; set; }
        public bool? OnlyAvailable { get; set; }
        public bool? OnlyExpiring { get; set; }
        public string? Location { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortBy { get; set; } = "name"; // "name", "category", "expiration", "quantity"
        public string SortOrder { get; set; } = "asc";
    }
    
}