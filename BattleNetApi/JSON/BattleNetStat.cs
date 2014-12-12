using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetStat
    {
        [JsonProperty("stat")]
        public int Stat { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}