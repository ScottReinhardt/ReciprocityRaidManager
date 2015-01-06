using System.Collections.Generic;
using WoW.Core.Models;

namespace WoW.Models
{
    public class AddRaiderModel
    {
        public PlayerModel NewRaider { get; set; }

        public IEnumerable<PlayerModel> Raiders { get; set; }

        public AddRaiderModel()
        {
            NewRaider = new PlayerModel();
        }
    }
}