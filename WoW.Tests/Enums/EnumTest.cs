using BattleNetApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoW.Core.Enums;

namespace WoW.Tests.Enums
{
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void TestClasses()
        {
            var client = new BattleNetApiClient();
            var dictionary = client.GetClasses();

            Assert.IsTrue(dictionary.CompareToEnum<Class>());
        }
        
        [TestMethod]
        public void TestRaces()
        {
            var client = new BattleNetApiClient();
            var dictionary = client.GetRaces();

            Assert.IsTrue(dictionary.CompareToEnum<Race>());
        }
    }
}
