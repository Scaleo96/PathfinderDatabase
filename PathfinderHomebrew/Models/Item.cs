using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string TypeName()
        {
            switch (Type)
            {
                case ItemType.Armor:
                    return "Armor";

                case ItemType.Ring:
                    return "Ring";

                case ItemType.Staff:
                    return "Staff";

                case ItemType.Weapon:
                    return "Weapon";

                case ItemType.Wondrous_Item:
                    return "Wondrous Item";
            }

            return "";
        }

        public ItemType Type { get; set; }
        [Display(Name = "Item Slot")]
        public ItemSlot ItemSlot { get; set; }
        public string Name { get; set; }
        [Display(Name = "Auras")]
        public List<AuraTypeM> AuraTypes { get; set; }
        [Display(Name = "Aura Strength")]
        public AuraStrength AuraStrength { get; set; }
        [Display(Name = "Caster Level")]
        public int CasterLevel { get; set; }
        public float Weight { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        [Display(Name = "Construction Requirements")]
        public string ConstructionRequirements { get; set; }

        public string AuraTypeString { get; set; }
        public string OwnerID { get; set; }
    }
}
