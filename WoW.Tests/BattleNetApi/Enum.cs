using BattleNetApi;
using NUnit.Framework;
using WoW.Core.Enums;

namespace WoW.Tests.BattleNetApi
{
    [TestFixture]
    class Enum
    {
        [Test]
        public void TestClasses()
        {
            var client = new BattleNetApiClient();
            var dictionary = client.GetClasses();

            Assert.IsTrue(dictionary.CompareToEnum<Class>());
        }

        [Test]
        public void TestRaces()
        {
            var client = new BattleNetApiClient();
            var dictionary = client.GetRaces();

            Assert.IsTrue(dictionary.CompareToEnum<Race>());
        }
    }
}
