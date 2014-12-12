using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetSpell
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("castTime")]
        public string CastTime { get; set; }

        [JsonProperty("cooldown")]
        public string Cooldown { get; set; }

        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("powerCost")]
        public string PowerCost { get; set; }
    }
}