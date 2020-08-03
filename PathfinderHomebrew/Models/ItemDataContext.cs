using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderHomebrew.Models
{
    public class ItemDataContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<SpellLikeAbility> spellLikeAbilities { get; set; }

        public ItemDataContext(DbContextOptions<ItemDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpellLikeAbility>()
            .HasOne(i => i.Item)
            .WithMany(c => c.spellLikeAbilities)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

