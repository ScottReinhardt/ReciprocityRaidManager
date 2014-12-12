using System.Web.Mvc;
using WoW.Core.Interfaces;

namespace WoW.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ICharacterImporter _importer;
        private readonly ILogApi _logApi;

        public HomeController(ICharacterImporter importer, ILogApi logApi)
        {
            _importer = importer;
            _logApi = logApi;
        }

        public ActionResult Index()
        {
            var model = _importer.GetCharacterProfileAndItems("Zarania", "Stormrage");
            model.LogsProfileLink = _logApi.GetCharacterProfile(model.Name,model.Realm, "US");
            return View(model);
        }

    }
}