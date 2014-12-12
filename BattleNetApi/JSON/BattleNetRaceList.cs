using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetRaceList
    {
        [JsonProperty("races")]
        public List<BattleNetRace> Races { get; set; }
    }
}