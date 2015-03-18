using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using WoW.Controllers;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.Models.Raid;
using WoW.Session;

namespace WoW.Tests.WoW.Web.Controllers
{
    [TestFixture]
    class RaidControllerTest
    {
        private ICharacterImporter _importer;
        private IWoWPersistanceProvider _dataProvider;
        private RaidController controller;
        private MockHttpContextBase context;
        [SetUp]
        public void Init()
        {
            _importer = Substitute.For<ICharacterImporter>();
            _dataProvider = Substitute.For<IWoWPersistanceProvider>();
            controller = new RaidController(_importer,_dataProvider);
            context = new MockHttpContextBase(controller, "");
            controller.Raid = Substitute.For<IRaidWrapper>();
        }

        [Test]
        public void IndexWhenRaidSessionNotNull()
        {
            controller.Raid.Raid.Returns(new RaidModel());
            var view = controller.Index() as ViewResult;

            Assert.AreEqual(view.ViewName, "");
        }

        [Test]
        public void IndexWhenRaidSessionFail()
        {
            controller.Raid.Raid.Returns(x => null);
            
            var redirect = controller.Index() as RedirectToRouteResult;

            Assert.AreEqual(redirect.RouteValues["action"], "Index");
            Assert.AreEqual(redirect.RouteValues["controller"], "Home");
        }

        [Test]
        public void RosterWithNullRaid()
        {
            controller.Raid.Raid.Returns(x => null);

            var redirect = controller.Roster() as RedirectToRouteResult;

            Assert.AreEqual(redirect.RouteValues["action"], "Index");
            Assert.AreEqual(redirect.RouteValues["controller"], "Home");
        }

        [Test]
        public void Roster()
        {
            controller.Raid.Raid.Returns(x => new RaidModel());

            var view = controller.Roster() as ViewResult;

            Assert.AreEqual(view.ViewName, "");
            var model = view.Model as AddRaiderModel;
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Raiders);
        }

        [Test]
        public void RemoveRaiderSuccess()
        {
            controller.Raid.Raid.Returns(x => new RaidModel{RaidId = 1, Raiders = new List<PlayerModel>{new PlayerModel{PlayerId = 2, RaidId = 1}}});
            _dataProvider.RemoveRaider(2, 1).Returns(true);
            var result = controller.RemoveRaider(2) as JsonResult;
            Assert.NotNull(result);
            Assert.AreEqual(result.Data, 2);
        }

        [Test]
        public void RemoveRaiderFail()
        {
            controller.Raid.Raid.Returns(x => new RaidModel { RaidId = 1, Raiders = new List<PlayerModel> { new PlayerModel { PlayerId = 2, RaidId = 1 } } });
            _dataProvider.RemoveRaider(2, 1).Returns(false);
            var result = controller.RemoveRaider(2) as HttpStatusCodeResult;
            Assert.NotNull(result);
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.BadRequest);
        }
    }
}
