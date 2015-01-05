using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.Core.Objects;
using WoW.Models;

namespace WoW.Controllers
{
    public class RaidController : Controller
    {
        private readonly ICharacterImporter _importer;
        private readonly IWoWPersistanceProvider _dataProvider;

        private IEnumerable<Enchant> _enchants;

        public RaidController(ICharacterImporter importer, IWoWPersistanceProvider dataProvider)
        {
            _importer = importer;
            _enchants = _importer.GetEnchants();
            _dataProvider = dataProvider;
        }

        public ActionResult RaiderDetails(int raidId)
        {
            var raid = _dataProvider.GetRaiderDetails(raidId);
            
            return View(raid);
        }

        public ActionResult Index(int raidId)
        {
            var raid = _dataProvider.GetRaiderDetails(raidId);
            var model = new AddRaiderModel()
            {
                Raiders = raid.Raiders,
            };
            return View(model);
        }

        public ActionResult NewRaider(PlayerModel raider)
        {
            
            return new EmptyResult();
        }
    }
}