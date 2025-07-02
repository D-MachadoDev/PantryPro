using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Dashboards
{
    public class DashboardStatsDto
    {
        // Estadísticas principales
        public int TotalIngredients { get; set; }
        public int ExpiringIngredients { get; set; }
        public int ExpiredIngredients { get; set; }
        public int TotalRecipes { get; set; }
        public int PublicRecipes { get; set; }
        public int TotalMealPlans { get; set; }
        public int ActiveMealPlans { get; set; }
        public int TotalPoints { get; set; }
        public int EarnedAchievements { get; set; }
        
        // Estadísticas financieras
        public decimal? TotalInvestment { get; set; }
        public decimal? EstimatedSavings { get; set; }
        public decimal? MonthlyAverage { get; set; }
        
        // Estadísticas nutricionales
        public decimal? WeeklyCalories { get; set; }
        public decimal? WeeklyProtein { get; set; }
        public decimal? WeeklyCarbs { get; set; }
        public decimal? WeeklyFat { get; set; }
        
        // Tendencias (últimos 30 días)
        public List<DailyStatsDto> DailyStats { get; set; } = new();
        
        // Próximas tareas
        public List<UpcomingTaskDto> UpcomingTasks { get; set; } = new();
        
        // Recomendaciones
        public List<string> Recommendations { get; set; } = new();
    }
}