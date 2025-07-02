using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.Core.DTOs.Dashboards
{
    public class UpcomingTaskDto
    {
        public string Type { get; set; } = string.Empty; // "expiration", "meal", "shopping"
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = string.Empty; // "low", "medium", "high"
        public string? ActionUrl { get; set; }
    }
}