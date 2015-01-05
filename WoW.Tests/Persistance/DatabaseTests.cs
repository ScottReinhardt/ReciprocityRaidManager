using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoW.Persistance;

namespace WoW.Tests.Persistance
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void ConnectToDatabase()
        {
            var db = new WoWDbProvider();
        }
    }
}
