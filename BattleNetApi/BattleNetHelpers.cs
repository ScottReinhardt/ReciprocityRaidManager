using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleNetApi.JSON;
using WoW.Core.Enums;
using WoW.Core.Models;
using WoW.Core.Objects;

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

        public static ItemModel ToItemModel(this BattleNetItem item)
        {
            if(item == null)
                return new ItemModel();
            
            return new ItemModel()
            {
                ItemLevel = item.ItemLevel,
                Name = item.Name,
                Quality = (ItemQuality)item.Quality,
                ItemStats = item.Stats.Select(s => new ItemStat(s.Stat, s.Amount)).ToList(),
                //Enchant = new Enchant { Id = item.TooltipParams.EnchantId },
            };
        }

        public static void UpdateEnchant(this ItemModel model, IEnumerable<Enchant> enchants)
        {
            //if (model == null || model.Enchant == null)
            //    return;
            //var enchant = enchants.FirstOrDefault(o => o.Id == model.Enchant.Id);
            //
            //if (enchant == null)
            //    return;
            //
            //model.Enchant.Bonus = enchant.Bonus;
        }

        public static void UpdateEnchants(this EquipmentModel model)
        {
            var client = new BattleNetApiClient();
            var enchants = client.GetEnchants();

            var enumerable = enchants as Enchant[] ?? enchants.ToArray();
            //model.Back.UpdateEnchant(enumerable);
            //model.Chest.UpdateEnchant(enumerable);
            //model.Feet.UpdateEnchant(enumerable);
            //model.Finger1.UpdateEnchant(enumerable);
            //model.Finger2.UpdateEnchant(enumerable);
            //model.Hands.UpdateEnchant(enumerable);
            //model.Head.UpdateEnchant(enumerable);
            //model.Legs.UpdateEnchant(enumerable);
            //model.MainHand.UpdateEnchant(enumerable);
            //model.Neck.UpdateEnchant(enumerable);
            //model.OffHand.UpdateEnchant(enumerable);
            //model.Shoulder.UpdateEnchant(enumerable);
            //model.Trinket1.UpdateEnchant(enumerable);
            //model.Trinket2.UpdateEnchant(enumerable);
            //model.Waist.UpdateEnchant(enumerable);
            //model.Wrist.UpdateEnchant(enumerable);
        }

        public static EquipmentModel ToEquipmentModel(this BattleNetItems items)
        {
            var model = new EquipmentModel()
            {
                AverageEquippedItemLevel = items.AverageItemLevelEquipped,
                AverageItemLevel = items.AverageItemLevel,
                Back = items.Back.ToItemModel(),
                Chest = items.Chest.ToItemModel(),
                Feet = items.Feet.ToItemModel(),
                Finger1 = items.Finger1.ToItemModel(),
                Finger2 = items.Finger2.ToItemModel(),
                Hands = items.Hands.ToItemModel(),
                Head = items.Head.ToItemModel(),
                Legs = items.Legs.ToItemModel(),
                MainHand = items.MainHand.ToItemModel(),
                Neck = items.Neck.ToItemModel(),
                OffHand = items.OffHand.ToItemModel(),
                Shoulder = items.Shoulder.ToItemModel(),
                Trinket1 = items.Trinket1.ToItemModel(),
                Trinket2 = items.Trinket2.ToItemModel(),
                Waist = items.Waist.ToItemModel(),
                Wrist = items.Wrist.ToItemModel(),
            };

            model.UpdateEnchants();

            return model;
        }

        public static Stat GetPrimaryStat(this BattleNetCharacter character)
        {
            switch (character.Class)
            {
                //strength
                case (int)Class.DeathKnight:
                case (int)Class.Warrior:
                    return Stat.Strength;
                //strength or int
                case (int)Class.Paladin:
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Holy":
                            return Stat.Intellect;
                    }
                    return Stat.Strength;
                //Agi
                case (int)Class.Hunter:
                case (int)Class.Rogue:
                    return Stat.Agility;
                //Agi or Int
                case (int)Class.Shaman:
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Enhancement":
                            return Stat.Agility;
                    }
                    return Stat.Intellect;
                case (int)Class.Druid:
                switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Restoration":
                        case "Balance":
                            return Stat.Intellect;
                    }
                    return Stat.Agility;
                case (int)Class.Monk:
                    switch (character.Specialization.First(s => s.Selected).Spec.Name)
                    {
                        case "Mistweaver":
                            return Stat.Intellect;
                    }
                    return Stat.Agility;
                //Int
                case (int)Class.Mage:
                case (int)Class.Priest:
                case (int)Class.Warlock:
                default:
                    return Stat.Intellect;
            }
        }

        public static PlayerModel ToPlayerModel(this BattleNetCharacter character)
        {
            var model = new PlayerModel()
            {
                ArmorType = character.GetArmorType(),
                Equipment = character.Items.ToEquipmentModel(),
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