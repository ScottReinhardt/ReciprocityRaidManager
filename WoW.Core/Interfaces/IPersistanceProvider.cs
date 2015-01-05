using WoW.Core.Models;

namespace WoW.Core.Interfaces
{
    public interface IWoWPersistanceProvider
    {
        bool RaidNameAvailable(string name);
        void CreateRaidGroup(string name);
        RaidModel GetRaiderDetails(int raidId);
    }
}
