using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetClassList
    {
        [JsonProperty("classes")]
        public List<BattleNetClass> Classes { get; set; }
    }
}