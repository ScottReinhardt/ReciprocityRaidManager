using System.ComponentModel.DataAnnotations;

namespace WoW.Enums
{
    public enum Race
    {
        //Alliance
        [Display(Name="Human")]
        AllianceHuman = 1,
        [Display(Name = "Dwarf")]
        AllianceDwarf = 3,
        [Display(Name = "Night Elf")]
        AllianceNightElf = 4,
        [Display(Name = "Gnome")]
        AllianceGnome = 7,
        [Display(Name = "Draenei")]
        AllianceDraenei = 11,
        [Display(Name = "Worgen")]
        AllianceWorgen = 22,
        [Display(Name = "Pandaren")]
        AlliancePandaren = 25,
        //Horde
        HordeOrc = 2,
        HordeUndead = 5,
        HordeTauren = 6,
        HordeTroll = 8,
        HordeGoblin = 9,
        HordeBloodElf = 10,
        HordePandaren = 26,
        //Neutral
        NeutralPandaren = 24,
    }
}