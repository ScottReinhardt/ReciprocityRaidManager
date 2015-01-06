using BattleNetApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoW.Core.Enums;

namespace WoW.Tests.Characters
{
    [TestClass]
    public class CharacterImportTest
    {
        [TestMethod]
        public void ImportZaraniaProfileAndItemsTest()
        {
            var client = new BattleNetApiClient();

            var character = client.GetCharacterProfileAndItems("Zarania", "Stormrage");
            
            
            Assert.IsNotNull(client.GetEnchants(), "Enchant count is wrong");
            Assert.IsNotNull(character, "Character is null");
            Assert.IsTrue(character.Name == "Zarania", "Loaded wrong character");
            Assert.IsTrue(character.Realm == "Stormrage", "Loaded wrong realm");
            Assert.IsTrue(character.ArmorType == ArmorType.Plate, "Armor Type wrong");
            Assert.IsTrue(character.BuffsBrought.Count > 0, "Buffs didn't load");
            Assert.IsTrue(character.Class == Class.DeathKnight, "Wrong class");
            Assert.IsFalse(character.Specialization.IsNullOrWhitespace(), "Specialization wrong");
            //Assert.IsFalse(Math.Abs(character.Equipment.AverageEquippedItemLevel - default(double)) < 0.1, "Average Equipped Item Level didn't load");
            //Assert.IsFalse(Math.Abs(character.Equipment.AverageItemLevel - default(double)) < 0.1, "Average Item Level didn't load");
            Assert.IsFalse(character.Role == default(Role), "Role didn't load");
        }
    }
}
