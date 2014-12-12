using Newtonsoft.Json;

namespace BattleNetApi.JSON
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