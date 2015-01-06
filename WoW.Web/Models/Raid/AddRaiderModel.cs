using System.Collections.Generic;
using WoW.Core.Models;

namespace WoW.Models.Raid
{
    public class AddRaiderModel
    {
        public PlayerModel NewRaider { get; set; }

        public List<PlayerModel> Raiders { get; set; }

        public AddRaiderModel()
        {
            NewRaider = new PlayerModel();
            Raiders = new List<PlayerModel>();
        }
    }
}