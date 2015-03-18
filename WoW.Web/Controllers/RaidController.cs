using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StructureMap;
using WoW.Core;
using WoW.Core.Enums;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.DependencyResolution;
using WoW.Models.Raid;
using WoW.Session;

namespace WoW.Controllers
{
    public class RaidController : Controller
    {
        private readonly ICharacterImporter _importer;
        private readonly IWoWPersistanceProvider _dataProvider;
        public IRaidWrapper Raid;

        public RaidController(ICharacterImporter importer, IWoWPersistanceProvider dataProvider)
        {
            _importer = importer;
            _dataProvider = dataProvider;
            IContainer container = IoC.Initialize();
            Raid = container.GetInstance<IRaidWrapper>();
            Raid.SetDataProviders(dataProvider, HttpContext);
        }

        public ActionResult Index()
        {
            var raid = Raid.Raid;

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
            var raid = Raid.Raid;

            if (raid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new AddRaiderModel()
            {
                Raiders = raid.Raiders ?? new List<PlayerModel>(),
            });
        }

        [HttpPost]
        public ActionResult RemoveRaider(int id)
        {
            try
            {
                var raid = Raid.Raid;
                if (!_dataProvider.RemoveRaider(id, raid.RaidId))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                
                raid.Raiders.Remove(raid.Raiders.First(p => p.PlayerId == id));
                return new JsonResult(){Data = id};
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
                player.RaidId = Raid.RaidId;
                if (_dataProvider.AddRaider(player))
                {
                    model.Raiders.Add(player);
                    Raid.Raid.Raiders.Add(player);
                    model.NewRaider = new PlayerModel();
                }
                else
                {
                    throw new Exception("Changes not saved successfully");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("PlayerNotFound", "Player not found or internal server error.  Please check server and name and try again.");
                return View("Roster", model);
            }
            return RedirectToAction("Roster");
        }

        public ActionResult RaidComp()
        {
            var raid = Raid.Raid;

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
            model.MailWearers = model.Raiders.Count(p => p.ArmorType == ArmorType.Mail);
            model.PlateWearers = model.Raiders.Count(p => p.ArmorType == ArmorType.Plate);


            model.ConquerorToken = model.Raiders.Count(p => p.Class.In(TierTokens.Conqueror));
            model.ProtectorToken = model.Raiders.Count(p => p.Class.In(TierTokens.Protector));
            model.VanquisherToken = model.Raiders.Count(p => p.Class.In(TierTokens.Vanquisher));

            var buffs = model.Raiders.Where(p => p.Class != Class.Hunter).SelectMany(o => o.BuffsBrought).Distinct().ToList();
            var allBuffs = Enum.GetValues(typeof(Buffs)).Cast<Buffs>();
            model.Hunters = model.Raiders.Count(p => p.Class == Class.Hunter);

            model.BuffsNotBrought = allBuffs.Where(b => !buffs.Contains(b)).ToList();

            model.RaidBuffs = buffs;

            return View(model);
        }
    }
}