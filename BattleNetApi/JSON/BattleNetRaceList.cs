using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetRaceList
    {
        [JsonProperty("races")]
        public List<BattleNetRace> Races { get; set; }
    }
}