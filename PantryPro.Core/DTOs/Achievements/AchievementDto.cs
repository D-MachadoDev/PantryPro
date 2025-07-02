using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Achievements
{
    public class AchievementDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? BadgeColor { get; set; }
        public int Points { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Requirements { get; set; }
        public bool IsActive { get; set; }
        
        // Para el usuario específico
        public bool IsEarned { get; set; }
        public DateTime? EarnedAt { get; set; }
        public decimal? Progress { get; set; } // Porcentaje de progreso hacia el logro
    }
}