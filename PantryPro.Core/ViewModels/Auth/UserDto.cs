using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.ViewModels.Auth
{
    public class UserDto
    {
        public string? Id { get; set; }            // GUID
        public string? Email { get; set; }
        public string? Username { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}