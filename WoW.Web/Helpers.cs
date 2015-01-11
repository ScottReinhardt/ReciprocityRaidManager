using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.Sessoin;
using WoW.Core.Attempt;

namespace WoW
{
    public static class Helpers
    {
        public static RaidModel GetRaidModelFromSessionOrProvider(this IWoWPersistanceProvider dataProvider)
        {
            var raid = RaidSession.Raid;

            if (raid != null)
            {
                return raid;
            }
            
            raid = dataProvider.GetRaiderDetails(RaidSession.RaidId);
            if (raid.Raiders != null)
            {
                raid.Raiders.OrderBy(p => p.Name);
            }

            RaidSession.Raid = raid;
            
            return raid;
        }

        public static Attempt<RaidModel> LoadRaidModel(this IWoWPersistanceProvider dataProvider)
        {
            var raid = dataProvider.GetRaidModelFromSessionOrProvider();
            return Attempt<RaidModel>.SucceedIf(raid != null, raid);
        }
    }
}