using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderHomebrew.Models
{
    public enum FreqType { Will, Minute, Day, Week, Month, Year }

    public class SpellLikeAbility
    {
        public long Id { get; set; }
        public FreqType FreqType { get; set; }
        public int Frequancy { get; set; }
        public string Name { get; set; }
        public Item Item { get; set; }
    }
}
