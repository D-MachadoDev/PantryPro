using System.ComponentModel.DataAnnotations;

namespace PantryPro.Core.ViewModels.Auth
{
    public class LoginUserDto
    {
        [Required, EmailAddress]
        public string? Email { get; set; }         // "ana.perez@example.com"

        [Required]
        public string? Password { get; set; }      // "P@ssw0rd!"
        
    }
}