using System.Web.Mvc;
using WoW.Core.Interfaces;
using WoW.Models.Home;

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
                var raidId = _dataProvider.GetRaidByName(model.GroupName, model.ServerName);
                Session["raidId"] = raidId;
                Session["raidName"] = model.GroupName;
                return RedirectToAction("Roster", "Raid");
            }

            var id =_dataProvider.CreateRaidGroup(model.GroupName, model.ServerName);

            Session["raidId"] = id;
            Session["raidName"] = model.GroupName;
            return RedirectToAction("Roster", "Raid");
        }
    }
}