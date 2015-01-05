using System.Data.Entity;
using System.Linq;
using WoW.Core.Interfaces;
using WoW.Core.Models;

namespace WoW.Persistance
{
    internal class WoWDbContext : DbContext
    {
        public DbSet<RaidModel> RaidGroup { get; set; }
        public DbSet<PlayerModel> Player { get; set; }
    }
}
