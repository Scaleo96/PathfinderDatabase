using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderHomebrew.Models
{
    public class AuraTypeM
    {
        public long Id { get; set; }
        public AuraType AuraType { get; set; }

        public AuraTypeM (long id, AuraType auraType)
        {
            Id = id;
            AuraType = auraType;
        }
    }
}
