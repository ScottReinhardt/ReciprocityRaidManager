using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Core.Enums;

namespace WoW.Core.Objects
{
    public class ItemStat
    {
        public ItemStat(Stat stat, int amount)
        {
            Stat = stat;
            Amount = amount;
        }

        public ItemStat(int stat, int amount)
        {
            Stat = (Stat) stat;
            Amount = amount;
        }
        [Key]
        public Stat Stat { get; set; }
        public int Amount { get; set; }

        public string StatName
        {
            get
            {
                var stat = Stat.GetAttributeOfType<DisplayAttribute>();
                return stat == null ? Stat.ToString() : stat.Name;
            }
        }
    }
}
