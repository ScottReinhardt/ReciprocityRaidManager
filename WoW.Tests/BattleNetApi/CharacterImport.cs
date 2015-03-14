using BattleNetApi;
using NUnit.Framework;
using WoW.Core.Enums;
using WoW.Core.Interfaces;

namespace WoW.Tests.BattleNetApi
{
    [TestFixture]
    public class CharacterImport
    {
        private readonly ICharacterImporter _importer = new BattleNetApiClient();

        [Test]
        public void GetCharacterProfile()
        {
            const string playerName = "Kyrenia";
            const string playerServer = "Stormrage";
            var player = _importer.GetCharacterProfile(playerName, playerServer);

            Assert.IsNotNull(player);
            Assert.AreEqual(player.ArmorType, ArmorType.Plate);
            Assert.AreEqual(player.Class, Class.Warrior);
            Assert.IsFalse(player.Role == default(Role));
            Assert.IsFalse(player.Race == default(Race));
            
            Assert.AreEqual(player.Name, playerName);
            Assert.AreEqual(player.Realm, playerServer);

            Assert.IsFalse(player.BuffsBrought.Count == 0);
            Assert.IsFalse(player.Specialization.IsNullOrWhitespace());
            Assert.IsFalse(player.LogsProfileLink == string.Empty);
        }

        [Test]
        public void GetCharacterProfileAndItems()
        {
            const string playerName = "Kyrenia";
            const string playerServer = "Stormrage";
            var player = _importer.GetCharacterProfileAndItems(playerName, playerServer);

            Assert.IsNotNull(player);
            Assert.IsNotNull(player.Equipment);
            Assert.IsFalse(player.Equipment.AverageEquippedItemLevel == default(float));
            Assert.IsFalse(player.Equipment.AverageItemLevel == default(float));

            Assert.AreEqual(player.ArmorType, ArmorType.Plate);
            Assert.AreEqual(player.Class, Class.Warrior);
            Assert.IsFalse(player.Role == default(Role));
            Assert.IsFalse(player.Race == default(Race));

            Assert.AreEqual(player.Name, playerName);
            Assert.AreEqual(player.Realm, playerServer);

            Assert.IsFalse(player.BuffsBrought.Count == 0);
            Assert.IsFalse(player.Specialization.IsNullOrWhitespace());
            Assert.IsFalse(player.LogsProfileLink == string.Empty);
        }
    }
}
