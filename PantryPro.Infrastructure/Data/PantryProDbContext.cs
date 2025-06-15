using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PantryPro.Infrastructure.Data
{
    public class PantryProDbContext : DbContext
    {
        public PantryProDbContext(DbContextOptions<PantryProDbContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities here
        // public DbSet<YourEntity> YourEntities { get; set; }

    }
}