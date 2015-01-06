using System.Collections.Generic;
using WoW.Core.Models;

namespace WoW.Models
{
    public class RaidSummaryModel
    {
        public IEnumerable<PlayerModel> Raiders { get; set; }
    }
}