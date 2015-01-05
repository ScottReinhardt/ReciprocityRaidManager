using System.ComponentModel.DataAnnotations;

namespace WoW.Core.Enums
{
    public enum Stat
    {
        Mana = 0,
        Health = 1,
        Agility = 3,
        Strength = 4,
        Intellect = 5,
        Spirit = 6,
        Stamina = 7,
        Defense = 12,
        Dodge = 13,
        Parry = 14,
        Block = 15,
        
        [Display(Name = "Melee Hit")]
        MeleeHit = 16,
        
        [Display(Name = "Ranged Hit")]
        RangedHit = 17,
        
        [Display(Name = "Spell Hit")]
        SpellHit = 18,
        
        [Display(Name = "Melee Critical Strike")]
        MeleeCriticalStrike = 19,
        
        [Display(Name = "Ranged Critical Strike")]
        RangedCriticalStrike = 20,
        
        [Display(Name = "Spell Critical Strike")]
        SpellCriticalStrike = 21,
        
        [Display(Name = "Melee Hit Avoidance")]
        MeleeHitAvoidance = 22,
        
        [Display(Name = "Ranged Hit Avoidance")]
        RangedHitAvoidance = 23,
        
        [Display(Name = "Spell Hit Avoidance")]
        SpellHitAvoidance = 24,

        [Display(Name = "Melee Critical Strike Avoidance")]
        MeleeCriticalStrikeAvoidance = 25,

        [Display(Name = "Ranged Critical Strike Avoidance")]
        RangedCriticalStrikeAvoidance = 26,

        [Display(Name = "Spell Critical Strike Avoidance")]
        SpellCriticalStrikeAvoidance = 27,

        [Display(Name = "Melee Haste")]
        MeleeHaste = 28,

        [Display(Name = "Ranged Haste")]
        RangedHaste = 29,

        [Display(Name = "Spell Haste")]
        SpellHaste = 30,

        Hit = 31,

        [Display(Name = "Critical Strike")]
        CriticalStrike = 32,

        [Display(Name = "Hit Avoidance")]
        HitAvoidance = 33,

        [Display(Name = "Critical Strike Avoidance")]
        CriticalStrikeAvoidance = 34,

        [Display(Name = "PvP Resilience")]
        PvPResilience = 35,

        Haste = 36,
        Expertise = 37,

        [Display(Name = "Attack Power")]
        AttackPower = 38,

        [Display(Name = "Ranged Attack Power")]
        RangedAttackPower = 39,

        Versatility = 40,

        [Display(Name = "Bonus Healing")]
        BonusHealing = 41,

        [Display(Name = "Bonus Damage")]
        BonusDamage = 42,

        [Display(Name = "Mana Regeneration")]
        ManaRegeneration = 43,

        [Display(Name = "Armor Penetration")]
        ArmorPenetration = 44,

        [Display(Name = "Spell Power")]
        SpellPower = 45,

        [Display(Name = "Health per Five Seconds")]
        HealthPerFiveSec = 46,

        [Display(Name = "Spell Penetration")]
        SpellPenetration = 47,

        [Display(Name = "Block Value")]
        BlockValue = 48,

        Mastery = 49,

        [Display(Name = "Bonus Armor")]
        BonusArmor = 50,

        [Display(Name = "Fire Resistance")]
        FireResistance = 51,

        [Display(Name = "Frost Resistance")]
        FrostResistance = 52,

        [Display(Name = "Holy Resistance")]
        HolyResistance = 53,

        [Display(Name = "Shadow Resistance")]
        ShadowResistance = 54,

        [Display(Name = "Nature Resistance")]
        NatureResistance = 55,

        [Display(Name = "Arcane Resistance")]
        ArcaneResistance = 56,

        [Display(Name = "PvP Power")]
        PvPPower = 57,

        Amplify = 58,
        Multistrike = 59,
        Readiness = 60,
        Speed = 61,
        Leech = 62,
        Avoidance = 63,
        Indestructible = 64,

        [Display(Name = "Unused #7")]
        UnusedSeven = 65,

        Cleave = 66,

        [Display(Name = "Unused #9")]
        UnusedNine = 67,

        [Display(Name = "Unused #10")]
        UnusedTen = 68,

        [Display(Name = "Unused #11")]
        UnusedEleven = 69,

        [Display(Name = "Unused #12")]
        UnusedTwelve = 70,

        [Display(Name = "Strength or Agility")]
        StrengthOrAgility = 72,

        [Display(Name = "Strength or Intellect")]
        StrengthOrIntellect = 74,
    }
}