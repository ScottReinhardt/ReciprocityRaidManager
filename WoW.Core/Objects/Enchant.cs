using System.ComponentModel.DataAnnotations;

namespace WoW.Core.Objects
{
    public class Enchant
    {
        public string Bonus { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
