using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using WoW.Controllers;
using WoW.Core.Attempt;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.Sessoin;

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
            context.HttpContext.Session["raidId"] = 1;
            context.HttpContext.Session["raid"] = new RaidModel();
            RaidSession.Session = context.HttpContext.Session;
        }

        [Test]
        public void GetRaidFromSession()
        {
            _dataProvider.GetRaiderDetails(1).Returns((RaidModel) null);
            var raid = _dataProvider.GetRaidModelFromSessionOrProvider();

            Assert.NotNull(raid);
        }

        [Test]
        public void GetRaidFromDataProvider()
        {
            _dataProvider.GetRaiderDetails(1).Returns(new RaidModel());
            context.HttpContext.Session["raid"] = null;
            var raid = _dataProvider.GetRaidModelFromSessionOrProvider();

            Assert.NotNull(raid);
            Assert.AreEqual(RaidSession.RaidId, 1);
            Assert.IsNotNull(RaidSession.Raid);
            Assert.AreEqual(RaidSession.Raid.GetType(), typeof(RaidModel));
        }

        [Test]
        public void IndexWhenRaidSessionNotNull()
        {
            var view = controller.Index() as ViewResult;

            Assert.AreEqual(view.ViewName, "");
        }

        [Test]
        public void IndexWhenRaidSessionFail()
        {
            _dataProvider.GetRaidModelFromSessionOrProvider().Returns(x => null);

            var redirect = controller.Index() as RedirectToRouteResult;

            Assert.AreEqual(redirect.RouteValues["action"], "Index");
            Assert.AreEqual(redirect.RouteValues["controller"], "Home");
        }
    }
}
