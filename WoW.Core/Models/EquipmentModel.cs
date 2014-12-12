using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Core.Models
{
    public class EquipmentModel
    {
        public double AverageItemLevel { get; set; }
        
        public double AverageEquippedItemLevel { get; set; }
       
        public ItemModel Head { get; set; }

        public ItemModel Neck { get; set; }

        public ItemModel Shoulder { get; set; }

        public ItemModel Back { get; set; }

        public ItemModel Chest { get; set; }

        public ItemModel Wrist { get; set; }

        public ItemModel Hands { get; set; }

        public ItemModel Waist { get; set; }

        public ItemModel Legs { get; set; }

        public ItemModel Feet { get; set; }

        public ItemModel Finger1 { get; set; }

        public ItemModel Finger2 { get; set; }

        public ItemModel Trinket1 { get; set; }

        public ItemModel Trinket2 { get; set; }

        public ItemModel MainHand { get; set; }

        public ItemModel OffHand { get; set; }
    }
}
