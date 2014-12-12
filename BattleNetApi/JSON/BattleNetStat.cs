using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetStat
    {
        [JsonProperty("stat")]
        public int Stat { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}