using System.Web;
using WoW.Core.Interfaces;
using WoW.Core.Models;

namespace WoW.Session
{
    public interface IRaidWrapper
    {
        RaidModel Raid { get; set; }

        int RaidId { get; set; }

        void SetDataProviders(IWoWPersistanceProvider persistance, HttpContextBase context);

        void SetDataProvider(IWoWPersistanceProvider persistance);

        void SetDataProvider(HttpContextBase context);

        void SetDataProvider(HttpSessionStateBase context);
    }
}
