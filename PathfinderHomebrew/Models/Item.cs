using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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
        [Required]
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
        [Display(Name = "Is Artifact?")]
        public bool Artifact { get; set; }
        [Display(Name = "Construction Requirements")]
        public string ConstructionRequirements { get; set; }
        public string Destruction { get; set; }
        public bool Intelligent { get; set; }

        [AllowNull]
        public string Alignment { get; set; }
        [AllowNull]
        public int? Ego { get; set; }
        [AllowNull]
        public string Senses { get; set; }
        [AllowNull]
        public int? Int { get; set; }
        [AllowNull]
        public int? Wis { get; set; }
        [AllowNull]
        public int? Cha { get; set; }
        [AllowNull]
        public string Communication { get; set; }
        [AllowNull]
        [Display(Name = "Special Purpose")]
        public string SpecialPurpose { get; set; }
        [AllowNull]
        [Display(Name = "Dedicated Power")]
        public string DedicatedPower { get; set; }
        [AllowNull]
        [Display(Name = "Spell Caster Level")]
        public int? CasterLevelI { get; set; }
        [AllowNull]
        public int? Concentration { get; set; }
        [Display(Name = "spell-Like Abilities")]
        public List<SpellLikeAbility> spellLikeAbilities { get; set; }
        [Display(Name = "Destruction Known")]
        public bool DestructionKnown { get; set; }

        public DateTime PostedDate { get; set; }
        public string AuraTypeString { get; set; }
        public string OwnerID { get; set; }

        public Item()
        {
            spellLikeAbilities = new List<SpellLikeAbility>();
        }
    }
}
