using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class ParseEnchant
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("bonus")]
        public string Bonus { get; set; }
    }

    public class ParseEnchants
    {
        [JsonProperty("enchants")]
        public List<ParseEnchant> Enchants;
    }
}
