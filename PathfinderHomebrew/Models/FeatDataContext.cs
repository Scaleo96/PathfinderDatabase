using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderHomebrew.Models
{
    public class FeatDataContext : DbContext
    {
        public DbSet<Feat> Feats { get; set; }

        public FeatDataContext(DbContextOptions<FeatDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
