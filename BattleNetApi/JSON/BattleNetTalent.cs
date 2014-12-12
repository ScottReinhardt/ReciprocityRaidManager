using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetTalent
    {
        [JsonProperty("tier")]
        public int Tier { get; set; }

        [JsonProperty("column")]
        public int Column { get; set; }

        [JsonProperty("spell")]
        public BattleNetSpell Spell { get; set; }
    }
}