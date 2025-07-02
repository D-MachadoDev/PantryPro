using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.ViewModels.Auth
{
    public class RegisterUserDto
    {
        [Required, EmailAddress]
        public string? Email { get; set; }         // "ana.perez@example.com"

        [Required, MinLength(6)]
        public string? Password { get; set; }      // "P@ssw0rd!"

        [Required]
        public string? Username { get; set; }      // "AnaPerez"
    }
}