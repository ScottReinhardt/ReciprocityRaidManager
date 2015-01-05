using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetTooltipParams
    {
        [JsonProperty("enchant")]
        public int EnchantId { get; set; }

        [JsonProperty("gem0")]
        public string GemId { get; set; }
    }
}
