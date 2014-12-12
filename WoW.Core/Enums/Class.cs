using System.ComponentModel.DataAnnotations;

namespace WoW.Core.Enums
{
    public enum Class
    {
        [Display(Name = "Death Knight")]
        DeathKnight = 6,
        Druid = 11,
        Hunter = 3,
        Mage = 8,
        Monk = 10,
        Paladin = 2,
        Priest = 5,
        Rogue = 4,
        Shaman = 7,
        Warlock = 9,
        Warrior = 1,
    }
}