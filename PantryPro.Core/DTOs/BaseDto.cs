using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}