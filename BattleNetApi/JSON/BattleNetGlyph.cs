using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetGlyph
    {
        [JsonProperty("glyph")]
        public int Glyph { get; set; }

        [JsonProperty("item")]
        public int Item { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}