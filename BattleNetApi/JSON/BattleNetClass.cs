using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetClass
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mask")]
        public int Mask { get; set; }

        [JsonProperty("powerType")]
        public string PowerType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}