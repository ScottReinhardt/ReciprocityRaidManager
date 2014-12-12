using WoW.Core.Models;

namespace WoW.Core.Interfaces
{
    public interface ICharacterImporter
    {
        PlayerModel GetCharacterProfile(string name, string server);
        PlayerModel GetCharacterProfileAndItems(string name, string server);
    }
}
