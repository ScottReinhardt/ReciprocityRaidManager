using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using WoW.Core.Enums;
using WoW.Core.Models;

namespace WoW.Core
{
    public static class Helpers
    {
        public static string UppercaseFirst(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }

        public static void TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                Console.WriteLine("Duplicate key: {0}", key);
                return;
            }
            dictionary.Add(key,value);
        }

        public static bool IsNullOrWhitespace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());

            if (memInfo.Length == 0) return null;

            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static List<Buffs> GetBuffsBrought(this PlayerModel character)
        {
            var buffs = new List<Buffs>();
            switch (character.Class)
            {
                case Class.DeathKnight:
                    buffs.Add(Buffs.AttackPower);
                    switch (character.Specialization)
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
                case Class.Paladin:
                    buffs.Add(Buffs.Mastery);
                    buffs.Add(Buffs.Stats);
                    switch (character.Specialization)
                    {
                        case "Retribution":
                            buffs.Add(Buffs.Versatility);
                            break;
                    }
                    break;
                case Class.Warrior:
                    buffs.Add(Buffs.Stamina);
                    buffs.Add(Buffs.AttackPower);
                    switch (character.Specialization)
                    {
                        case "Arms":
                        case "Fury":
                            buffs.Add(Buffs.Versatility);
                            break;
                    }
                    break;
                case Class.Hunter:
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
                case Class.Shaman:
                    buffs.Add(Buffs.Haste);
                    buffs.Add(Buffs.Heroism);
                    buffs.Add(Buffs.Mastery);
                    break;
                case Class.Druid:
                    buffs.Add(Buffs.Stats);
                    buffs.Add(Buffs.Versatility);
                    switch (character.Specialization)
                    {
                        case "Balance":
                            buffs.Add(Buffs.Mastery);
                            break;
                        case "Feral":
                            buffs.Add(Buffs.CriticalStrike);
                            break;
                    }
                    break;
                case Class.Rogue:
                    buffs.Add(Buffs.Haste);
                    buffs.Add(Buffs.Multistike);
                    break;
                case Class.Monk:
                    buffs.Add(Buffs.CriticalStrike);
                    buffs.Add(Buffs.Stats);
                    switch (character.Specialization)
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
                case Class.Mage:
                    buffs.Add(Buffs.CriticalStrike);
                    buffs.Add(Buffs.Heroism);
                    buffs.Add(Buffs.SpellPower);
                    break;
                case Class.Priest:
                    buffs.Add(Buffs.Stamina);
                    switch (character.Specialization)
                    {
                        case "Shadow":
                            buffs.Add(Buffs.Haste);
                            buffs.Add(Buffs.Multistike);
                            break;
                    }
                    break;
                case Class.Warlock:
                    buffs.Add(Buffs.Multistike);
                    buffs.Add(Buffs.SpellPower);
                    buffs.Add(Buffs.Stamina);
                    break;
            }
            return buffs;
        }
    }
}