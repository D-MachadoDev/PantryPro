using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Achievements
{
    public class UserAchievementDto : BaseDto
    {
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public string AchievementName { get; set; } = string.Empty;
        public string AchievementDescription { get; set; } = string.Empty;
        public string? AchievementImageUrl { get; set; }
        public string? BadgeColor { get; set; }
        public int Points { get; set; }
        public DateTime EarnedAt { get; set; }
    }
}