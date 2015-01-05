using System.ComponentModel.DataAnnotations;

namespace WoW.Core.Models
{
    public class EquipmentModel
    {
        [Key]
        public int EquipmentSetId { get; set; }
        public double AverageItemLevel { get; set; }
        
        public double AverageEquippedItemLevel { get; set; }
       
        public virtual ItemModel Head { get; set; }

        public virtual ItemModel Neck { get; set; }

        public virtual ItemModel Shoulder { get; set; }

        public virtual ItemModel Back { get; set; }

        public virtual ItemModel Chest { get; set; }

        public virtual ItemModel Wrist { get; set; }

        public virtual ItemModel Hands { get; set; }

        public virtual ItemModel Waist { get; set; }

        public virtual ItemModel Legs { get; set; }

        public virtual ItemModel Feet { get; set; }

        public virtual ItemModel Finger1 { get; set; }

        public virtual ItemModel Finger2 { get; set; }

        public virtual ItemModel Trinket1 { get; set; }

        public virtual ItemModel Trinket2 { get; set; }

        public virtual ItemModel MainHand { get; set; }

        public virtual ItemModel OffHand { get; set; }
    }
}
