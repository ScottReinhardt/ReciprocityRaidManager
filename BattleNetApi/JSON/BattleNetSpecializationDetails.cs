using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetSpecializationDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("backgroundImage")]
        public string BackgroundImage { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}