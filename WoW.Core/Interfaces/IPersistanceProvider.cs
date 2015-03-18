using WoW.Core.Models;

namespace WoW.Core.Interfaces
{
    public interface IWoWPersistanceProvider
    {
        bool RaidNameAvailable(string name, string server);
        int GetRaidByName(string name, string server);
        int CreateRaidGroup(string name, string server);
        bool AddRaider(PlayerModel raider);
        bool RemoveRaider(int raiderId, int raidId);
        RaidModel GetRaiderDetails(int raidId);
    }
}
