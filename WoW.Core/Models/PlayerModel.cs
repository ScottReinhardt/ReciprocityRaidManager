using System.Collections.Generic;
using WoW.Enums;

namespace WoW.Core.Models
{
    public class PlayerModel
    {
        //Character Information
        public string Name { get; set; }
        public string Realm { get; set; }

        public double AverageItemLevel { get; set; }
        public double AverageEquippedItemLevel { get; set; }

        public double SimcraftDps { get; set; }

        public Class Class { get; set; }

        public Race Race { get; set; }

        //Raid Comp
        public Role Role { get; set; }
        public string Specialization { get; set; }
        public ArmorType ArmorType { get; set; }

        public List<Buffs> BuffsBrought { get; set; }

        //Raid Loot
        public int EffortPoints { get; set; }

        public int GearPoints { get; set; }

    }
}