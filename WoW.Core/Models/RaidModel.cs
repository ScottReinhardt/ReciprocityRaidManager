using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WoW.Core.Models
{
    public class RaidModel
    {
        [Key]
        public int RaidId { get; set; }
        public string RaidName { get; set; }
        public string Server { get; set; }
        public virtual IEnumerable<PlayerModel> Raiders { get; set; }
    }
}
