using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.Core.Attempt;
using WoW.Session;

namespace WoW
{
    public static class Helpers
    {
        public static bool In<T>(this T o, IEnumerable<T> enumerable)
        {
            return enumerable.Contains(o);
        }
    }
}