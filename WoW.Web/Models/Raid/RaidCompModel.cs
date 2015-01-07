using System.Collections.Generic;
using WoW.Core.Enums;
using WoW.Core.Models;

namespace WoW.Models.Raid
{
    public class RaidCompModel
    {
        public IEnumerable<PlayerModel> Raiders { get; set; }

        public int ClothWearers { get; set; }
        public int LeatherWearers { get; set; }
        public int Mailearers { get; set; }
        public int PlateWearers { get; set; }

        public List<Buffs> RaidBuffs { get; set; }

        public List<Buffs> BuffsNotBrought { get; set; }

        public int Hunters { get; set; }
    }
}