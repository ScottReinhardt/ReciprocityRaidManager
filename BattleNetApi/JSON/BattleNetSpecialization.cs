using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetSpecialization
    {
        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("talents")]
        public List<BattleNetTalent> Talents { get; set; }

        [JsonProperty("glyphs")]
        public BattleNetGlyphs Glyphs { get; set; }

        [JsonProperty("spec")]
        public BattleNetSpecializationDetails Spec { get; set; }

        [JsonProperty("calcTalent")]
        public string CalcTalent { get; set; }

        [JsonProperty("calcSpec")]
        public string CalcSpec { get; set; }

        [JsonProperty("calcGlyph")]
        public string CalcGlyph { get; set; }
    }
}