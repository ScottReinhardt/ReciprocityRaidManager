using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WoW.BattleNet.JSON
{
    public class BattleNetCharacter
    {
        [JsonProperty("lastModified")]
        public long LastModified { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("realm")]
        public string Realm { get; set; }
        
        [JsonProperty("battlegroup")]
        public string Battlegroup { get; set; }
        
        [JsonProperty("class")]
        public int Class { get; set; }
        
        [JsonProperty("race")]
        public int Race { get; set; }
        
        [JsonProperty("gender")]
        public int Gender { get; set; }
        
        [JsonProperty("level")]
        public int Level { get; set; }
        
        [JsonProperty("achievementPoints")]
        public int AchievementPoints { get; set; }
        
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        
        [JsonProperty("calcClass")]
        public string CalcClass { get; set; }
        
        [JsonProperty("items")]
        public BattleNetItems Items { get; set; }

        [JsonProperty("talents")]
        public List<BattleNetSpecialization> Specialization { get; set; }
            
        [JsonProperty("totalHonorableKills")]
        public int TotalHonorableKills { get; set; }
    }
}