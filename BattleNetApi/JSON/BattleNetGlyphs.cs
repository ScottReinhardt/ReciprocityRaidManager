using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetGlyphs
    {
        [JsonProperty("major")]
        public List<BattleNetGlyph> Major { get; set; }

        [JsonProperty("minor")]
        public List<BattleNetGlyph> Minor { get; set; }
    }
}