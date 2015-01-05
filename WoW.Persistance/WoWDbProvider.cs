using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Core.Interfaces;
using WoW.Core.Models;

namespace WoW.Persistance
{
    public class WoWDbProvider : IWoWPersistanceProvider
    {
        private WoWDbContext _dbContext { get; set; }

        public WoWDbProvider()
        {
            _dbContext = new WoWDbContext();
        }

        public bool RaidNameAvailable(string name)
        {
            return _dbContext.RaidGroup.None(r => r.RaidName == name);
        }

        public void CreateRaidGroup(string name)
        {
            _dbContext.RaidGroup.Add(new RaidModel { RaidName = name });
            _dbContext.SaveChanges();
        }

        public RaidModel GetRaiderDetails(int raidId)
        {
            throw new NotImplementedException();
        }
    }
}
