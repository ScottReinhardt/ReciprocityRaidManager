using System.Collections.Generic;
using WoW.Core.Models;

namespace WoW.Models.Raid
{
    public class RaidSummaryModel
    {
        public IEnumerable<PlayerModel> Raiders { get; set; }
    }
}