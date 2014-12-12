using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WoW.Enums
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