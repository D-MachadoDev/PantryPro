using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Search
{
    public class RecipeSearchDto
    {
        public string? Query { get; set; }
        public List<int> IngredientIds { get; set; } = new();
        public List<string> Tags { get; set; } = new();
        public string? CuisineType { get; set; }
        public string? MealType { get; set; }
        public int? MaxCookingTime { get; set; }
        public int? Difficulty { get; set; }
        public bool? IsVegetarian { get; set; }
        public bool? IsVegan { get; set; }
        public bool? IsGlutenFree { get; set; }
        public bool? OnlyWithAvailableIngredients { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortBy { get; set; } = "created"; // "created", "rating", "cookingTime", "difficulty"
        public string SortOrder { get; set; } = "desc"; // "asc", "desc"
    }
}