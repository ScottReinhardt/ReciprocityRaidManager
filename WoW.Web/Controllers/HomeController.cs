using System.Collections.Generic;
using System.Web.Mvc;
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

            if (!_dataProvider.RaidNameAvailable(model.GroupName))
            {
                ModelState.AddModelError("GroupName", "Group Name Already Taken");
                return View("Index", model);
            }

            _dataProvider.CreateRaidGroup(model.GroupName);
            return RedirectToAction("Index", "Raid");
        }
    }
}