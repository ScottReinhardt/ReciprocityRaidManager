using System.Collections.Generic;
using WoW.Core.Models;

namespace WoW.Models
{
    public class AddRaiderModel
    {
        public IEnumerable<PlayerModel> Raiders { get; set; }

        public PlayerModel NewRaider { get; set; }

        public AddRaiderModel()
        {
            NewRaider = new PlayerModel();
        }
    }
}