﻿using System;
using System.Collections.Generic;

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
    }
}