using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Models.Users;

namespace PantryPro.Core.Models.Achievements
{
    public class UserAchievement : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int AchievementId { get; set; }
        
        [Required]
        public DateTime EarnedAt { get; set; } = DateTime.UtcNow;
        
        // Relaciones
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("AchievementId")]
        public virtual Achievement Achievement { get; set; } = null!;
    }
}