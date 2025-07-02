using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Users
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool EmailVerified { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public bool NotificationsEnabled { get; set; }
        public bool ExpirationAlertsEnabled { get; set; }
        public int ExpirationAlertDays { get; set; }
        
        // Estadísticas calculadas
        public int TotalRecipes { get; set; }
        public int TotalMealPlans { get; set; }
        public int TotalPoints { get; set; }
        public string SubscriptionStatus { get; set; } = "Free";
        
    }
}