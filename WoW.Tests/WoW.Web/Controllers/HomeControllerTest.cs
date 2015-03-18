using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using WoW.Controllers;
using WoW.Core.Interfaces;
using WoW.Models.Home;

namespace WoW.Tests.WoW.Web.Controllers
{
    [TestFixture]
    class HomeControllerTest
    {
        private HomeController controller;
        private ILogApi api;
        private IWoWPersistanceProvider persistance;
        private ICharacterImporter importer;

        private const string passName = "Reciprocity Alts";
        private const string failName = "Reciprocity Core";

        private const string passServer = "Hyjal";
        private const string failServer = "Stormrage";
        private MockHttpContextBase context;

        [SetUp]
        public void Init()
        {
            importer = Substitute.For<ICharacterImporter>();
            api = Substitute.For<ILogApi>();
            persistance = Substitute.For<IWoWPersistanceProvider>();
            controller = new HomeController(importer, api, persistance);
            context = new MockHttpContextBase(controller, "");

            persistance.RaidNameAvailable(passName, passServer).Returns(true);
            persistance.RaidNameAvailable(failName, failServer).Returns(false);
            persistance.CreateRaidGroup(passName, passServer).Returns(1);
            persistance.GetRaidByName(failName, failServer).Returns(1);
        }

        [Test]
        public void Index()
        {
            var view = controller.Index() as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as CreateRaidModel;
            Assert.IsNotNull(model);
            Assert.IsNull(model.GroupName);
            Assert.IsNull(model.ServerName);
        }
        
        [Test]
        public void CreateRaidGroupMissingRequiredFields()
        {
            var model = new CreateRaidModel()
            {
                GroupName = null,
                ServerName = null,
            };
            controller.ModelState.AddModelError("Required", "Required");
            var view = controller.CreateRaidGroup(model) as ViewResult;

            Assert.AreEqual(view.ViewName, "Index");
         }

        [Test]
        public void CreateRaidGroupAvailable()
        {
            var model = new CreateRaidModel()
            {
                GroupName = passName,
                ServerName = passServer,
            };
            var redirect = controller.CreateRaidGroup(model) as RedirectToRouteResult;
            persistance.Received().CreateRaidGroup(passName, passServer);

            Assert.AreEqual(redirect.RouteValues["action"], "Roster");
            Assert.AreEqual(redirect.RouteValues["controller"], "Raid");
            Assert.AreEqual(context.HttpContext.Session["raidId"], 1);
            Assert.AreEqual(context.HttpContext.Session["raidName"], passName);
        }

        [Test]
        public void CreateRaidGroupTaken()
        {
            var model = new CreateRaidModel()
            {
                GroupName = failName,
                ServerName = failServer,
            };
            var redirect = controller.CreateRaidGroup(model) as RedirectToRouteResult;
            persistance.Received().GetRaidByName(failName, failServer);

            Assert.AreEqual(redirect.RouteValues["action"], "Roster");
            Assert.AreEqual(redirect.RouteValues["controller"], "Raid");
            Assert.AreEqual(context.HttpContext.Session["raidId"], 1);
            Assert.AreEqual(context.HttpContext.Session["raidName"], failName);
        }
    }
}
