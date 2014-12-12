using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Core.Interfaces;

namespace WarcraftLogs
{
    public class WarcraftLogsApi : ILogApi
    {
        public const string _baseApiLink = "https://www.warcraftlogs.com/rankings/character_name/{0}/{1}/{2}";

        public WarcraftLogsApi()
        {
            
        }

        public string GetCharacterProfile(string characterName, string server, string region)
        {
            return string.Format(_baseApiLink, characterName, server, region);
        }
    }
}
