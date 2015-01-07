using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WoW.Core.Enums;
using WoW.Core.Objects;

namespace WoW.Core.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public ItemQuality Quality { get; set; }
        public int ItemLevel { get; set; }
        public virtual List<ItemStat> ItemStats { get; set; }
        public virtual Enchant Enchant { get; set; }

        [NotMapped]
        public string ValidationError { get; set; }
    }
}