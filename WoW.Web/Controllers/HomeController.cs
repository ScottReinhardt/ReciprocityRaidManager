using System.Web.Mvc;
using WoW.Core.Interfaces;
using WoW.Core.Models;

namespace WoW.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ICharacterImporter _importer;

        public HomeController(ICharacterImporter importer)
        {
            _importer = importer;
        }

        public ActionResult Index()
        {
            var model = _importer.GetCharacterProfileAndItems("Zarania", "Stormrage");
            return View(model);
        }

    }
}