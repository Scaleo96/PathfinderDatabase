using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PathfinderHomebrew.Models
{
    public enum FeatType { General, Combat, Metamagic, Story, Misc }
    public class Feat
    {
        public long Id { get; set; }

        private string _key;

        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Name.ToLower(), "[^a-z0-9]", "-");
                }

                return _key;
            }

            set { _key = value; }
        }

        public FeatType Type { get; set; }
        public string Name { get; set; }
        public string Benefits { get; set; }
        public string Special { get; set; }
        public string Normal { get; set; }
        public string Prerequisites { get; set; }
        public string FlavorText { get; set; }
        [Display(Name = "Abridged Benefit")]
        public string BenefitAbridged { get; set; }

        public string OwnerID { get; set; }
    }
}
