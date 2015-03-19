using System.Web;
using WoW.Core.Interfaces;
using WoW.Core.Models;

namespace WoW.Session
{
    public class RaidWrapper : IRaidWrapper
    {
        private IWoWPersistanceProvider _dataProvider { get; set; }
        private HttpSessionStateBase _sessionProvider { get; set; }
        private int _raidId { get; set; }

        public int RaidId
        {
            get { return (int)_sessionProvider["raidId"]; }
            set { _sessionProvider["raidId"] = value; }
        }

        public RaidModel Raid
        {
            get
            {
                var raid = _sessionProvider["raid"] as RaidModel;
                if (raid != null)
                {
                    return raid;
                }
                raid = _dataProvider.GetRaiderDetails(_raidId);
                _sessionProvider["raid"] = raid;
                return raid;
            }

            set { _sessionProvider["raid"] = value; }
        }
        
        public void SetDataProviders(IWoWPersistanceProvider persistance, HttpContextBase context)
        {
            _dataProvider = persistance;
            if (context == null || context.Session == null)
            {
                return;
            }
            _sessionProvider = context.Session;
            _raidId = (int)context.Session["raidId"];
        }

        public void SetDataProvider(IWoWPersistanceProvider persistance)
        {
            _dataProvider = persistance;
        }

        public void SetDataProvider(HttpContextBase context)
        {
            _sessionProvider = context.Session;
        }

        public void SetDataProvider(HttpSessionStateBase context)
        {
            _sessionProvider = context;
        }
    }
}