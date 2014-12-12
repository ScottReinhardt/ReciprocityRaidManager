using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetWeaponDamage
    {
        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("exactMin")]
        public double ExactMin { get; set; }

        [JsonProperty("exactMax")]
        public double ExactMax { get; set; }
    }
}