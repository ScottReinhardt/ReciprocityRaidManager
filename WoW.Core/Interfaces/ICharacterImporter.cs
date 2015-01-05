using System.Collections.Generic;
using WoW.Core.Models;
using WoW.Core.Objects;

namespace WoW.Core.Interfaces
{
    public interface ICharacterImporter
    {
        PlayerModel GetCharacterProfile(string name, string server);
        PlayerModel GetCharacterProfileAndItems(string name, string server);
        IEnumerable<Enchant> GetEnchants();
    }
}
