using System.Web;
using System.Web.SessionState;
using WoW.Core.Models;

namespace WoW.Sessoin
{
    public static class RaidSession
    {


        private static HttpSessionStateBase _session;
        public static HttpSessionStateBase Session
        {
            get { return _session ?? new HttpSessionStateWrapper(HttpContext.Current.Session); }
            set { _session = value; }
        }
        public static int RaidId
        {
            get { return Session["raidId"] as int? ?? 0; }
            set { Session["raidId"] = value; }
        }

        public static RaidModel Raid
        {
            get { return Session["raid"] as RaidModel; }
            set { Session["raid"] = value; }
        }
    }
}