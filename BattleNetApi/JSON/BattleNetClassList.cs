using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetClassList
    {
        [JsonProperty("classes")]
        public List<BattleNetClass> Classes { get; set; }
    }
}