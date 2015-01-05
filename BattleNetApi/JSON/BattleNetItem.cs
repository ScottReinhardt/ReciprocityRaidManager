using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("itemLevel")]
        public int ItemLevel { get; set; }

        [JsonProperty("stats")]
        public List<BattleNetStat> Stats { get; set; }

        [JsonProperty("armor")]
        public int Armor { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("bonusLists")]
        public List<object> BonusLists { get; set; }

        [JsonProperty("tooltipParams")]
        public BattleNetTooltipParams TooltipParams { get; set; }
    }
}