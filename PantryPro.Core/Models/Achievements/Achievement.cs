using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Enums;

namespace PantryPro.Core.Models.Achievements
{
public class Achievement : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        
        [StringLength(50)]
        public string? BadgeColor { get; set; }
        
        [Required]
        public int Points { get; set; }
        
        [Required]
        public AchievementType Type { get; set; }
        
        [StringLength(500)]
        public string? Requirements { get; set; } // JSON con los requisitos
        
        public new bool IsActive { get; set; } = true;
        
        // Relaciones
        public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    }
}