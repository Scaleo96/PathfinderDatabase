using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PathfinderHomebrew.Models
{
    public enum ItemType { Armor, Weapon, Ring, Staff, Wondrous_Item, Misc }
    public enum ItemSlot { Belt, Head, Body, Neck, Eyes, Shoulders, Feet, Wrists, Hand, Slotless }
    public enum AuraStrength { Faint, Moderate, Strong, Overwhelming }
    public enum AuraType { Abjuration, Conjuration, Divination, Enchantment, Evocation, Illusion, Necromancy, Transmutation }
    public class Item
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

        public ItemType Type { get; set; }
        public ItemSlot ItemSlot { get; set; }
        public string Name { get; set; }
        public List<AuraTypeM> AuraTypes { get; set; }
        public AuraStrength AuraStrength { get; set; }
        public int CasterLevel { get; set; }
        public float Weight { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ConstructionRequirements { get; set; }
    }
}
