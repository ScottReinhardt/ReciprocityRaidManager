using System;
using System.Collections.Generic;
using System.Linq;
using WoW.BattleNet.JSON;
using WoW.Core;
using WoW.Core.Models;
using WoW.Enums;

namespace BattleNetApi
{
    public static class BattleNetHelpers
    {
        public static ArmorType GetArmorType(this BattleNetCharacter character)
        {
            switch (character.Class)
            {
                case (int)Class.DeathKnight:
                case (int)Class.Paladin:
                case (int)Class.Warrior:
                    return ArmorType.Plate;
                case (int)Class.Hunter:
                case (int)Class.Shaman:
                    return ArmorType.Mail;
                case (int)Class.Druid:
                case (int)Class.Rogue:
                case (int)Class.Monk:
                    return ArmorType.Leather;
                case (int)Class.Mage:
                case (int)Class.Priest:
                case (int)Class.Warlock:
                default:
                    return ArmorType.Cloth;
            }
        }

        public static List<Buffs> GetBuffsBrought(this BattleNetCharacter character)
        {
            var buffs = new List<Buffs>();
            switch (character.Class)
            {
                case (int)Class.DeathKnight:
                    buffs.Add(Buffs.AttackPower);
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Unholy":
                        case "Frost":
                            buffs.Add(Buffs.Haste);
                            buffs.Add(Buffs.Versatility);
                            break;
                        case "Blood":
                            buffs.Add(Buffs.Mastery);
                            break;
                    }
                    break;
                case (int)Class.Paladin:
                    buffs.Add(Buffs.Mastery);
                    buffs.Add(Buffs.Stats);
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Retribution":
                            buffs.Add(Buffs.Versatility);
                            break;
                    }
                    break;
                case (int)Class.Warrior:
                    buffs.Add(Buffs.Stamina);
                    buffs.Add(Buffs.AttackPower);
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Arms":
                        case "Fury":
                            buffs.Add(Buffs.Versatility);
                            break;
                    }
                    break;
                case (int)Class.Hunter:
                    buffs.Add(Buffs.AttackPower);
                    buffs.Add(Buffs.CriticalStrike);
                    buffs.Add(Buffs.Haste);
                    buffs.Add(Buffs.Heroism);
                    buffs.Add(Buffs.Mastery);
                    buffs.Add(Buffs.Multistike);
                    buffs.Add(Buffs.SpellPower);
                    buffs.Add(Buffs.Stamina);
                    buffs.Add(Buffs.Stats);
                    buffs.Add(Buffs.Versatility);
                    break;
                case (int)Class.Shaman:
                    buffs.Add(Buffs.Haste);
                    buffs.Add(Buffs.Heroism);
                    buffs.Add(Buffs.Mastery);
                    break;
                case (int)Class.Druid:
                    buffs.Add(Buffs.Stats);
                    buffs.Add(Buffs.Versatility);
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Balance":
                            buffs.Add(Buffs.Mastery);
                            break;
                        case "Feral":
                            buffs.Add(Buffs.CriticalStrike);
                            break;
                    }
                    break;
                case (int)Class.Rogue:
                    buffs.Add(Buffs.Haste);
                    buffs.Add(Buffs.Multistike);
                    break;
                case (int)Class.Monk:
                    buffs.Add(Buffs.CriticalStrike);
                    buffs.Add(Buffs.Stats);
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Brewmaster":
                            buffs.Add(Buffs.CriticalStrike);
                            break;
                        case "Windwalker":
                            buffs.Add(Buffs.CriticalStrike);
                            buffs.Add(Buffs.Multistike);
                            break;
                    }
                    break;
                case (int)Class.Mage:
                    buffs.Add(Buffs.CriticalStrike);
                    buffs.Add(Buffs.Heroism);
                    buffs.Add(Buffs.SpellPower);
                    break;
                case (int)Class.Priest:
                    buffs.Add(Buffs.Stamina);
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Shadow":
                            buffs.Add(Buffs.Haste);
                            buffs.Add(Buffs.Multistike);
                            break;
                    }
                    break;
                case (int)Class.Warlock:
                    buffs.Add(Buffs.Multistike);
                    buffs.Add(Buffs.SpellPower);
                    buffs.Add(Buffs.Stamina);
                    break;
            }
            return buffs;
        }

        public static PlayerModel ToPlayerModel(this BattleNetCharacter character)
        {
            var model = new PlayerModel()
            {
                ArmorType = character.GetArmorType(),
                AverageItemLevel = character.Items.AverageItemLevel,
                AverageEquippedItemLevel = character.Items.AverageItemLevelEquipped,
                BuffsBrought = character.GetBuffsBrought(),
                Class = (Class)character.Class,
                Name = character.Name,
                Race = (Race)character.Race,
                Realm = character.Realm,
                Role = (Role)Enum.Parse(typeof(Role),character.Specialization.First(s => s.Selected).Spec.Role.ToLower().UppercaseFirst()),
                Specialization = character.Specialization.First(s => s.Selected).Spec.Name,
            };

            return model;
        }
    }
}