using System.Web;
using System.Web.SessionState;
using WoW.Core.Models;

namespace WoW.Sessoin
{
    public static class RaidSession
    {
        private static HttpSessionState _session { get { return HttpContext.Current.Session; } }
        public static int RaidId
        {
            get { return _session["raidId"] as int? ?? 0; }
            set { _session["raidId"] = value; }
        }

        public static RaidModel Raid
        {
            get { return _session["raid"] as RaidModel; }
            set { _session["raid"] = value; }
        }
    }
}