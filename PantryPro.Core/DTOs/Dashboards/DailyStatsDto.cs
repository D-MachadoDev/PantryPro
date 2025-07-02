using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Dashboards
{
    public class DailyStatsDto
    {
        public DateTime Date { get; set; }
        public int IngredientsAdded { get; set; }
        public int IngredientsConsumed { get; set; }
        public int RecipesCreated { get; set; }
        public int MealsCompleted { get; set; }
        public decimal? MoneySpent { get; set; }
        public decimal? CaloriesConsumed { get; set; }
    }
}