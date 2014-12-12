using WoW.Enums;

namespace WoW.Core.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public ItemQuality Quality { get; set; }
        public int ItemLevel { get; set; }
    }
}