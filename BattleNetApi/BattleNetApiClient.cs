using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using BattleNetApi.JSON;
using WoW.Core;
using WoW.Core.Interfaces;
using WoW.Core.Models;

namespace BattleNetApi
{

    public class BattleNetApiClient : ICharacterImporter
    {
        public string Test()
        {
            return "";
        }
        private WebClient _client { get; set; }
        private string _apiKey { get; set; }
        private string _apiRegion { get; set; }
        
        private const string _apiBase = "https://{0}.api.battle.net/wow/{1}&apikey={2}";
        
        public BattleNetApiClient(string apiKey, string apiRegion)
        {
            _client = new WebClient();
            _apiKey = apiKey;
            _apiRegion = apiRegion;
        }
        
        public BattleNetApiClient()
            : this(ConfigurationManager.AppSettings["ApiKey"], ConfigurationManager.AppSettings["ApiRegion"])
        {
            
        }
        
        private string GetApiString(string apiPath)
        {
            return string.Format(_apiBase, _apiRegion, apiPath,_apiKey);
        }
        
        public PlayerModel GetCharacterProfile(string name, string server)
        {
            var apiPath = string.Format("character/{0}/{1}?fields=items&locale=en_US", server, name);
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var character = str.ConvertJsonToObject<BattleNetCharacter>();
        
            var model = character.ToPlayerModel();
        
            return model;
        }
        
        public PlayerModel GetCharacterProfileAndItems(string name, string server)
        {
            var apiPath = string.Format("character/{0}/{1}?fields=talents,items&locale=en_US", server, name);
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var character = str.ConvertJsonToObject<BattleNetCharacter>();
        
            var model = character.ToPlayerModel();
        
            return model;
        }
        
        public Dictionary<string, int> GetClasses()
        {
            var apiPath = string.Format("data/character/classes?fields=items&locale=en_US");
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var model = str.ConvertJsonToObject<BattleNetClassList>();
        
            var dictionary = model.Classes.ToDictionary(c => c.Name, c => c.Id);
        
            return dictionary;
        }
        
        public Dictionary<string, int> GetRaces()
        {
            var apiPath = string.Format("data/character/races?fields=items&locale=en_US");
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var model = str.ConvertJsonToObject<BattleNetRaceList>();
        
            var dictionary = model.Races.Distinct().ToDictionary(c => c.Side.UppercaseFirst() + c.Name, c => c.Id);
        
            return dictionary;
        }
    }
}