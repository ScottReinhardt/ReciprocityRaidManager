using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WoW.Core.Enums;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.Core.Objects;
using WoW.Models;
using WoW.Models.Raid;

namespace WoW.Controllers
{
    public class RaidController : Controller
    {
        private readonly ICharacterImporter _importer;
        private readonly IWoWPersistanceProvider _dataProvider;

        private int RaidId
        {
            get { return Session["raidId"] == null ? 0 : (int) Session["raidId"]; }
            set { Session["raidId"] = value;  }
        }

        private string RaidName { get { return (string) Session["raidName"];  } }

        public RaidController(ICharacterImporter importer, IWoWPersistanceProvider dataProvider)
        {
            _importer = importer;
            _dataProvider = dataProvider;
        }

        public ActionResult Index()
        {
            if (RaidId == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            var raid = _dataProvider.GetRaiderDetails(RaidId);

            if (raid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RaidSummaryModel()
            {
                Raiders = raid.Raiders ?? new List<PlayerModel>(),
            };
            return View(model);
        }

        public ActionResult Roster()
        {
            var raid = _dataProvider.GetRaiderDetails(RaidId);
            return View(new AddRaiderModel()
            {
                Raiders = raid.Raiders ?? new List<PlayerModel>()
            });
        }

        [HttpPost]
        public ActionResult NewRaider(AddRaiderModel model)
        {
            try
            {
                var player = _importer.GetCharacterProfileAndItems(model.NewRaider.Name, model.NewRaider.Realm);
                player.LogsProfileLink = string.Format(
                    "https://www.warcraftlogs.com/rankings/character_name/{0}/{1}/us",
                    model.NewRaider.Name, model.NewRaider.Realm);
                player.RaidId = RaidId;
                if (_dataProvider.AddRaider(player))
                {
                    model.Raiders.Add(player);
                    model.NewRaider = new PlayerModel();
                }
                else
                {
                    throw new Exception("Changes not saved successfully");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("PlayerNotFound", "Player not found or internal server error.  Please check server and name and try again.");
                return View("Roster", model);
            }
            return RedirectToAction("Roster");
        }

        public ActionResult RaidComp()
        {
            if (RaidId == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            var raid = _dataProvider.GetRaiderDetails(RaidId);

            if (raid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RaidCompModel()
            {
                Raiders = raid.Raiders ?? new List<PlayerModel>(),
            };
            model.ClothWearers = model.Raiders.Count(p => p.ArmorType == ArmorType.Cloth);
            model.LeatherWearers = model.Raiders.Count(p => p.ArmorType == ArmorType.Leather);
            model.Mailearers = model.Raiders.Count(p => p.ArmorType == ArmorType.Mail);
            model.PlateWearers = model.Raiders.Count(p => p.ArmorType == ArmorType.Plate);

            var buffs = model.Raiders.Where(p => p.Class != Class.Hunter).SelectMany(o => o.BuffsBrought).Distinct().ToList();
            var allBuffs = Enum.GetValues(typeof(Buffs)).Cast<Buffs>();
            model.Hunters = model.Raiders.Count(p => p.Class == Class.Hunter);

            model.BuffsNotBrought = allBuffs.Where(b => !buffs.Contains(b)).ToList();

            model.RaidBuffs = buffs;

            return View(model);
        }
    }
}