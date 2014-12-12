using System;
using System.Collections.Generic;

namespace WoW.Tests
{
    public static class Helpers
    {
        public static bool CompareToEnum<T>(this Dictionary<string, int> enumerable)
        {
            bool success = true;
            foreach (var item in enumerable)
            {
                try
                {
                    var e = Enum.Parse(typeof (T), item.Key.Replace(" ", string.Empty));
                    success &= (int) e == item.Value;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return false;
                }
            }
            return success;
        }
    }
}
