using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetGlyphs
    {
        [JsonProperty("major")]
        public List<BattleNetGlyph> Major { get; set; }

        [JsonProperty("minor")]
        public List<BattleNetGlyph> Minor { get; set; }
    }
}