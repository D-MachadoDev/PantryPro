using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Users
{
    public class UserPreferenceDto : BaseDto
    {
        public int UserId { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsKeto { get; set; }
        public bool IsPaleo { get; set; }
        public List<string> Allergies { get; set; } = new();
        public List<string> DislikedIngredients { get; set; } = new();
        public int MaxCookingTimeMinutes { get; set; } = 60;
        public List<string> PreferredCuisineTypes { get; set; } = new();
        public int PreferredServingSize { get; set; } = 4;
        public int? DailyCalorieGoal { get; set; }
        public int? DailyProteinGoal { get; set; }
        public int? DailyCarbGoal { get; set; }
        public int? DailyFatGoal { get; set; }
        
    }
}