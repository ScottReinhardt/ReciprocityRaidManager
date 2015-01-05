using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using WoW.Core.Interfaces;
using WoW.Core.Objects;
using WoW.Models;

namespace WoW.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly IWoWPersistanceProvider _dataProvider;

        public HomeController(ICharacterImporter importer, ILogApi logApi, IWoWPersistanceProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public ActionResult Index()
        {
            return View(new CreateRaidModel());
        }

        public ActionResult CreateRaidGroup(CreateRaidModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            if (!_dataProvider.RaidNameAvailable(model.GroupName, model.ServerName))
            {
                return RedirectToAction("Index", "Raid", new {raidId = _dataProvider.GetRaidByName(model.GroupName, model.ServerName)});
            }

            var id =_dataProvider.CreateRaidGroup(model.GroupName, model.ServerName);
            return RedirectToAction("Index", "Raid", new {raidId = id});
        }
    }
}