
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetItems
    {
        [JsonProperty("averageItemLevel")]
        public int AverageItemLevel { get; set; }
        
        [JsonProperty("averageItemLevelEquipped")]
        public int AverageItemLevelEquipped { get; set; }

        [JsonProperty("head")]
        public BattleNetItem Head { get; set; }
        
        [JsonProperty("neck")]
        public BattleNetItem Neck { get; set; }
        
        [JsonProperty("shoulder")]
        public BattleNetItem Shoulder { get; set; }

        [JsonProperty("back")]
        public BattleNetItem Back { get; set; }

        [JsonProperty("chest")]
        public BattleNetItem Chest { get; set; }

        [JsonProperty("wrist")]
        public BattleNetItem Wrist { get; set; }

        [JsonProperty("hands")]
        public BattleNetItem Hands { get; set; }

        [JsonProperty("waist")]
        public BattleNetItem Waist { get; set; }

        [JsonProperty("legs")]
        public BattleNetItem Legs { get; set; }

        [JsonProperty("feet")]
        public BattleNetItem Feet { get; set; }

        [JsonProperty("finger1")]
        public BattleNetItem Finger1 { get; set; }

        [JsonProperty("finger2")]
        public BattleNetItem Finger2 { get; set; }

        [JsonProperty("trinket1")]
        public BattleNetItem Trinket1 { get; set; }

        [JsonProperty("trinket2")]
        public BattleNetItem Trinket2 { get; set; }

        [JsonProperty("mainHand")]
        public BattleNetItem MainHand { get; set; }

        [JsonProperty("offHand")]
        public BattleNetItem OffHand { get; set; }
    }
}