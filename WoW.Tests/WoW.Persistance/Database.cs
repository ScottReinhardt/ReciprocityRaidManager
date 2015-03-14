using NUnit.Framework;
using WoW.Core.Models;
using WoW.Persistance;
using WoW.Tests.Attributes;

namespace WoW.Tests.WoW.Persistance
{
    [TestFixture, Rollback]
    class Database
    {
        private WoWDbProvider db;
        
        [TestFixtureSetUp]
        public void Init()
        {
             db = new WoWDbProvider();
        }

        [Test]
        public void DbConnectionSucceeds()
        {
            Assert.IsNotNull(db);
        }

        [Test]
        public void GetRaidByName()
        {
            Assert.DoesNotThrow(() => db.GetRaidByName("Reciprocity Core", "Stormrage"));
        }

        [Test]
        public void GetRaiderDetails()
        {
            Assert.DoesNotThrow(() => db.GetRaiderDetails(0));
        }

        [Test]
        public void AddRaider()
        {
            Assert.DoesNotThrow(() => db.AddRaider(new PlayerModel()));
        }
    }
}
