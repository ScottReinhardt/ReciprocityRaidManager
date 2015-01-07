using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WoW.Core.Enums;

namespace WoW.Core.Models
{
    public class PlayerModel
    {
        [Key]
        public int PlayerId { get; set; }
        //Character Information
        public string Name { get; set; }
        public string Realm { get; set; }

        public double SimcraftDps { get; set; }

        public Class Class { get; set; }

        public Race Race { get; set; }

        public Stat PrimaryStat { get; set; }

        [Display(Name = "Logs Profile Link")]
        public string LogsProfileLink { get; set; }

        public virtual EquipmentModel Equipment { get; set; }

        //Raid Comp
        public Role Role { get; set; }
        public string Specialization { get; set; }
        public ArmorType ArmorType { get; set; }

        public virtual List<Buffs> BuffsBrought { get; set; }

        //Raid Loot
        public int EffortPoints { get; set; }

        public int GearPoints { get; set; }

        public int RaidId { get; set; }
        public virtual RaidModel Raid { get; set; }
    }
}