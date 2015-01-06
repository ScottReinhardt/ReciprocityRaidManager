using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using BattleNetApi.JSON;
using WoW.Core;
using WoW.Core.Interfaces;
using WoW.Core.Models;
using WoW.Core.Objects;

namespace BattleNetApi
{

    public class BattleNetApiClient : ICharacterImporter
    {
        public string Test()
        {
            return "";
        }
        private WebClient _client { get; set; }
        private string _apiKey { get; set; }
        private string _apiRegion { get; set; }
        
        private const string _apiBase = "https://{0}.api.battle.net/wow/{1}&apikey={2}";

        private const string _enchantJson =
            @"{""enchants"":[{""id"":""5324"",""bonus"":""+50 Critical Strike""},{""id"":""5325"",""bonus"":""+50 Haste""},{""id"":""5326"",""bonus"":""+50 Mastery""},{""id"":""5327"",""bonus"":""+50 Multistrike""},{""id"":""5328"",""bonus"":""+50 Versatility""},{""id"":""5317"",""bonus"":""+75 Critical Strike""},{""id"":""5318"",""bonus"":""+75 Haste""},{""id"":""5319"",""bonus"":""+75 Mastery""},{""id"":""5320"",""bonus"":""+75 Multistrike""},{""id"":""5321"",""bonus"":""+75 Versatility""},{""id"":""5310"",""bonus"":""+100 Critical Strike & +10% Speed""},{""id"":""5311"",""bonus"":""+100 Haste & +10% Speed""},{""id"":""5312"",""bonus"":""+100 Mastery & +10% Speed""},{""id"":""5313"",""bonus"":""+100 Multistrike & +10% Speed""},{""id"":""5314"",""bonus"":""+100 Versatility & +10% Speed""},{""id"":""5330"",""bonus"":""Mark of the Thunderlord""},{""id"":""5331"",""bonus"":""Mark of the Shattered Hand""},{""id"":""5335"",""bonus"":""Mark of Shadowmoon""},{""id"":""5336"",""bonus"":""Mark of Blackrock""},{""id"":""5337"",""bonus"":""Mark of Warsong""},{""id"":""5334"",""bonus"":""Mark of the Frostwolf""},{""id"":""5384"",""bonus"":""Mark of Bleeding Hollow""},{""id"":""5284"",""bonus"":""+30 Critical Strike""},{""id"":""5297"",""bonus"":""+30 Haste""},{""id"":""5299"",""bonus"":""+30 Mastery""},{""id"":""5301"",""bonus"":""+30 Multistrike""},{""id"":""5303"",""bonus"":""+30 Versatility""},{""id"":""5285"",""bonus"":""+40 Critical Strike""},{""id"":""5292"",""bonus"":""+40 Haste""},{""id"":""5293"",""bonus"":""+40 Mastery""},{""id"":""5294"",""bonus"":""+40 Multistrike""},{""id"":""5295"",""bonus"":""+40 Versatility""},{""id"":""5281"",""bonus"":""+100 Critical Strike""},{""id"":""5298"",""bonus"":""+100 Haste""},{""id"":""5300"",""bonus"":""+100 Mastery""},{""id"":""5302"",""bonus"":""+100 Multistrike""},{""id"":""5304"",""bonus"":""+100 Versatility""},{""id"":""4441"",""bonus"":""Windsong""},{""id"":""4442"",""bonus"":""Jade Spirit""},{""id"":""4443"",""bonus"":""Elemental Force""},{""id"":""4444"",""bonus"":""Dancing Steel""},{""id"":""4445"",""bonus"":""Colossus""},{""id"":""4446"",""bonus"":""River's Song""},{""id"":""4411"",""bonus"":""+170 Mastery""},{""id"":""4412"",""bonus"":""+170 Dodge""},{""id"":""4414"",""bonus"":""+180 Intellect""},{""id"":""4415"",""bonus"":""+180 Strength""},{""id"":""4416"",""bonus"":""+180 Agility""},{""id"":""4417"",""bonus"":""+200 PvP Resilience""},{""id"":""4418"",""bonus"":""+200 Spirit""},{""id"":""4419"",""bonus"":""+80 All Stats""},{""id"":""4420"",""bonus"":""+300 Stamina""},{""id"":""4421"",""bonus"":""+180 Critical Strike""},{""id"":""4422"",""bonus"":""+200 Stamina""},{""id"":""4423"",""bonus"":""+180 Intellect""},{""id"":""4424"",""bonus"":""+180 Critical Strike""},{""id"":""4426"",""bonus"":""+175 Haste""},{""id"":""4427"",""bonus"":""+175 Critical Strike""},{""id"":""4428"",""bonus"":""+140 Agility & Minor Speed Increase""},{""id"":""4429"",""bonus"":""+140 Mastery & Minor Speed Increase""},{""id"":""4430"",""bonus"":""+170 Haste""},{""id"":""4431"",""bonus"":""+170 Haste""},{""id"":""4432"",""bonus"":""+170 Strength""},{""id"":""4433"",""bonus"":""+170 Mastery""},{""id"":""4434"",""bonus"":""+165 Intellect""},{""id"":""4993"",""bonus"":""+170 Parry""},{""id"":""4066"",""bonus"":""Mending""},{""id"":""4258"",""bonus"":""+50 Agility""},{""id"":""4256"",""bonus"":""+50 Strength""},{""id"":""4257"",""bonus"":""+50 Intellect""},{""id"":""4061"",""bonus"":""+50 Mastery""},{""id"":""4062"",""bonus"":""+30 Stamina and Minor Movement Speed""},{""id"":""4063"",""bonus"":""+15 All Stats""},{""id"":""4064"",""bonus"":""+56 PvP Power""},{""id"":""4065"",""bonus"":""+50 Haste""},{""id"":""4067"",""bonus"":""Avalanche""},{""id"":""4068"",""bonus"":""+50 Haste""},{""id"":""4069"",""bonus"":""+50 Haste""},{""id"":""4070"",""bonus"":""+55 Stamina""},{""id"":""4071"",""bonus"":""+50 Critical Strike""},{""id"":""4072"",""bonus"":""+30 Intellect""},{""id"":""4073"",""bonus"":""+16 Stamina""},{""id"":""4074"",""bonus"":""Elemental Slayer""},{""id"":""4075"",""bonus"":""+35 Strength""},{""id"":""4076"",""bonus"":""+35 Agility""},{""id"":""4077"",""bonus"":""+40 PvP Resilience""},{""id"":""4082"",""bonus"":""+50 Haste""},{""id"":""4083"",""bonus"":""Hurricane""},{""id"":""4084"",""bonus"":""Heartsong""},{""id"":""4085"",""bonus"":""+50 Mastery""},{""id"":""4086"",""bonus"":""+50 Dodge""},{""id"":""4087"",""bonus"":""+50 Critical Strike""},{""id"":""4088"",""bonus"":""+40 Spirit""},{""id"":""4089"",""bonus"":""+50 Critical Strike""},{""id"":""4090"",""bonus"":""+30 Stamina""},{""id"":""4091"",""bonus"":""+40 Intellect""},{""id"":""4092"",""bonus"":""+50 Critical Strike""},{""id"":""4093"",""bonus"":""+50 Spirit""},{""id"":""4094"",""bonus"":""+50 Mastery""},{""id"":""4095"",""bonus"":""+50 Haste""},{""id"":""4096"",""bonus"":""+50 Intellect""},{""id"":""4097"",""bonus"":""Power Torrent""},{""id"":""4098"",""bonus"":""Windwalk""},{""id"":""4099"",""bonus"":""Landslide""},{""id"":""4100"",""bonus"":""+65 Critical Strike""},{""id"":""4101"",""bonus"":""+65 Critical Strike""},{""id"":""4102"",""bonus"":""+20 All Stats""},{""id"":""4103"",""bonus"":""+75 Stamina""},{""id"":""4105"",""bonus"":""+25 Agility and Minor Movement Speed""},{""id"":""4104"",""bonus"":""+35 Mastery and Minor Movement Speed""},{""id"":""4106"",""bonus"":""+50 Strength""},{""id"":""4107"",""bonus"":""+65 Mastery""},{""id"":""4108"",""bonus"":""+65 Haste""},{""id"":""4227"",""bonus"":""+130 Agility""},{""id"":""3225"",""bonus"":""Executioner""},{""id"":""3844"",""bonus"":""+45 Spirit""},{""id"":""3239"",""bonus"":""Icebreaker Weapon""},{""id"":""3241"",""bonus"":""Lifeward""},{""id"":""3247"",""bonus"":""+70 Attack Power versus Undead""},{""id"":""3251"",""bonus"":""Giantslaying""},{""id"":""3830"",""bonus"":""+50 Spell Power""},{""id"":""3828"",""bonus"":""+42 Attack Power""},{""id"":""1103"",""bonus"":""+26 Agility""},{""id"":""3273"",""bonus"":""Deathfrost""},{""id"":""3790"",""bonus"":""Black Magic""},{""id"":""1606"",""bonus"":""+25 Attack Power""},{""id"":""3827"",""bonus"":""+55 Attack Power""},{""id"":""3833"",""bonus"":""+32 Attack Power""},{""id"":""3834"",""bonus"":""+63 Spell Power""},{""id"":""3789"",""bonus"":""Berserking""},{""id"":""3788"",""bonus"":""+50 Critical Strike""},{""id"":""3854"",""bonus"":""+81 Spell Power""},{""id"":""3855"",""bonus"":""+69 Spell Power""},{""id"":""3233"",""bonus"":""+250 Mana""},{""id"":""3231"",""bonus"":""+15 Haste""},{""id"":""3234"",""bonus"":""+20 Critical Strike""},{""id"":""1952"",""bonus"":""+20 Dodge""},{""id"":""3236"",""bonus"":""+200 Health""},{""id"":""4747"",""bonus"":""+16 Agility""},{""id"":""1147"",""bonus"":""+18 Spirit""},{""id"":""2381"",""bonus"":""+20 Spirit""},{""id"":""3829"",""bonus"":""+17 Attack Power""},{""id"":""1075"",""bonus"":""+22 Stamina""},{""id"":""5259"",""bonus"":""+20 Agility""},{""id"":""1119"",""bonus"":""+16 Intellect""},{""id"":""1600"",""bonus"":""+19 Attack Power""},{""id"":""3243"",""bonus"":""+28 PvP Power""},{""id"":""3244"",""bonus"":""+14 Spirit and +14 Stamina""},{""id"":""3245"",""bonus"":""+20 PvP Resilience""},{""id"":""4748"",""bonus"":""+16 Agility""},{""id"":""1951"",""bonus"":""+18 Dodge""},{""id"":""3246"",""bonus"":""+28 Spell Power""},{""id"":""3826"",""bonus"":""+24 Critical Strike""},{""id"":""2661"",""bonus"":""+3 All Stats""},{""id"":""3252"",""bonus"":""+8 All Stats""},{""id"":""3253"",""bonus"":""+2% Threat and +10 Parry""},{""id"":""3256"",""bonus"":""+10 Agility and +40 Armor""},{""id"":""2326"",""bonus"":""+23 Spell Power""},{""id"":""3294"",""bonus"":""+25 Stamina""},{""id"":""1953"",""bonus"":""+22 Dodge""},{""id"":""3831"",""bonus"":""+23 Haste""},{""id"":""3296"",""bonus"":""+10 Spirit and 2% Reduced Threat""},{""id"":""3297"",""bonus"":""+275 Health""},{""id"":""3232"",""bonus"":""+15 Stamina and Minor Speed Increase""},{""id"":""3824"",""bonus"":""+12 Attack Power""},{""id"":""1128"",""bonus"":""+25 Intellect""},{""id"":""3825"",""bonus"":""+15 Haste""},{""id"":""1099"",""bonus"":""+22 Agility""},{""id"":""1603"",""bonus"":""+22 Attack Power""},{""id"":""3832"",""bonus"":""+10 All Stats""},{""id"":""1597"",""bonus"":""+16 Attack Power""},{""id"":""2332"",""bonus"":""+30 Spell Power""},{""id"":""3845"",""bonus"":""+25 Attack Power""},{""id"":""3850"",""bonus"":""+40 Stamina""},{""id"":""4746"",""bonus"":""+7 Weapon Damage""},{""id"":""2666"",""bonus"":""+30 Intellect""},{""id"":""2667"",""bonus"":""+35 Attack Power""},{""id"":""2668"",""bonus"":""+20 Strength""},{""id"":""2669"",""bonus"":""+40 Spell Power""},{""id"":""2670"",""bonus"":""+35 Agility""},{""id"":""2671"",""bonus"":""+50 Arcane and Fire Spell Power""},{""id"":""2672"",""bonus"":""+54 Shadow and Frost Spell Power""},{""id"":""2673"",""bonus"":""Mongoose""},{""id"":""2674"",""bonus"":""Spellsurge""},{""id"":""2675"",""bonus"":""Battlemaster""},{""id"":""3846"",""bonus"":""+40 Spell Power""},{""id"":""3222"",""bonus"":""+20 Agility""},{""id"":""2657"",""bonus"":""+12 Agility""},{""id"":""2622"",""bonus"":""+12 Dodge""},{""id"":""2647"",""bonus"":""+12 Strength""},{""id"":""1891"",""bonus"":""+4 All Stats""},{""id"":""2648"",""bonus"":""+14 Dodge""},{""id"":""5183"",""bonus"":""+15 Spell Power""},{""id"":""2679"",""bonus"":""+12 Spirit""},{""id"":""2649"",""bonus"":""+12 Stamina""},{""id"":""5184"",""bonus"":""+15 Spell Power""},{""id"":""2653"",""bonus"":""+12 Dodge""},{""id"":""2654"",""bonus"":""+12 Intellect""},{""id"":""2655"",""bonus"":""+15 Parry""},{""id"":""2656"",""bonus"":""+10 Spirit and +10 Stamina""},{""id"":""2658"",""bonus"":""+10 Haste and +10 Critical Strike""},{""id"":""2659"",""bonus"":""+150 Health""},{""id"":""2662"",""bonus"":""+120 Armor""},{""id"":""5237"",""bonus"":""+15 Spirit""},{""id"":""3150"",""bonus"":""+14 Spirit""},{""id"":""2933"",""bonus"":""+15 PvP Resilience""},{""id"":""2934"",""bonus"":""+10 Critical Strike""},{""id"":""2935"",""bonus"":""+15 Critical Strike""},{""id"":""5250"",""bonus"":""+15 Strength""},{""id"":""5255"",""bonus"":""+13 Attack Power""},{""id"":""2937"",""bonus"":""+20 Spell Power""},{""id"":""2322"",""bonus"":""+19 Spell Power""},{""id"":""369"",""bonus"":""+12 Intellect""},{""id"":""5257"",""bonus"":""+12 Attack Power""},{""id"":""2938"",""bonus"":""+16 PvP Power""},{""id"":""5258"",""bonus"":""+12 Agility""},{""id"":""2939"",""bonus"":""Minor Speed and +6 Agility""},{""id"":""2940"",""bonus"":""Minor Speed and +9 Stamina""},{""id"":""1071"",""bonus"":""+18 Stamina""},{""id"":""3229"",""bonus"":""+12 PvP Resilience""},{""id"":""5260"",""bonus"":""+18 Dodge""},{""id"":""4723"",""bonus"":""+2 Weapon Damage""},{""id"":""249"",""bonus"":""+2 Beastslaying""},{""id"":""250"",""bonus"":""+1  Weapon Damage""},{""id"":""723"",""bonus"":""+3 Intellect""},{""id"":""255"",""bonus"":""+3 Spirit""},{""id"":""241"",""bonus"":""+2 Weapon Damage""},{""id"":""943"",""bonus"":""+3 Weapon Damage""},{""id"":""853"",""bonus"":""+6 Beastslaying""},{""id"":""854"",""bonus"":""+6 Elemental Slayer""},{""id"":""4745"",""bonus"":""+3 Weapon Damage""},{""id"":""1897"",""bonus"":""+5 Weapon Damage""},{""id"":""803"",""bonus"":""Fiery Weapon""},{""id"":""912"",""bonus"":""Demonslaying""},{""id"":""963"",""bonus"":""+7 Weapon Damage""},{""id"":""805"",""bonus"":""+4 Weapon Damage""},{""id"":""1894"",""bonus"":""Icy Chill""},{""id"":""1896"",""bonus"":""+9 Weapon Damage""},{""id"":""1898"",""bonus"":""Lifestealing""},{""id"":""1899"",""bonus"":""Unholy Weapon""},{""id"":""1900"",""bonus"":""Crusader""},{""id"":""1903"",""bonus"":""+9 Spirit""},{""id"":""1904"",""bonus"":""+9 Intellect""},{""id"":""2443"",""bonus"":""+7 Frost Spell Damage""},{""id"":""2504"",""bonus"":""+30 Spell Power""},{""id"":""2505"",""bonus"":""+29 Spell Power""},{""id"":""2563"",""bonus"":""+15 Strength""},{""id"":""2564"",""bonus"":""+15 Agility""},{""id"":""2567"",""bonus"":""+20 Spirit""},{""id"":""2568"",""bonus"":""+22 Intellect""},{""id"":""2646"",""bonus"":""+25 Agility""},{""id"":""3869"",""bonus"":""Blade Ward""},{""id"":""3870"",""bonus"":""Blood Draining""},{""id"":""4720"",""bonus"":""+5 Health""},{""id"":""41"",""bonus"":""+5 Health""},{""id"":""44"",""bonus"":""Absorption (10)""},{""id"":""924"",""bonus"":""+2 Dodge""},{""id"":""24"",""bonus"":""+5 Mana""},{""id"":""4721"",""bonus"":""+1 Stamina""},{""id"":""242"",""bonus"":""+15 Health""},{""id"":""243"",""bonus"":""+1 Spirit""},{""id"":""783"",""bonus"":""+10 Armor""},{""id"":""246"",""bonus"":""+20 Mana""},{""id"":""4725"",""bonus"":""+1 Agility""},{""id"":""248"",""bonus"":""+1 Strength""},{""id"":""254"",""bonus"":""+25 Health""},{""id"":""4727"",""bonus"":""+3 Spirit""},{""id"":""66"",""bonus"":""+1 Stamina""},{""id"":""247"",""bonus"":""+1 Agility""},{""id"":""4722"",""bonus"":""+1 Stamina""},{""id"":""4724"",""bonus"":""+1 Agility""},{""id"":""744"",""bonus"":""+20 Armor""},{""id"":""4733"",""bonus"":""+30 Armor""},{""id"":""4728"",""bonus"":""+3 Spirit""},{""id"":""4730"",""bonus"":""+3 Stamina""},{""id"":""823"",""bonus"":""+3 Strength""},{""id"":""63"",""bonus"":""Absorption (25)""},{""id"":""843"",""bonus"":""+30 Mana""},{""id"":""844"",""bonus"":""+2 Mining""},{""id"":""845"",""bonus"":""+2 Herbalism""},{""id"":""2603"",""bonus"":""+2 Fishing""},{""id"":""4729"",""bonus"":""+3 Intellect""},{""id"":""847"",""bonus"":""+1 All Stats""},{""id"":""4731"",""bonus"":""+3 Stamina""},{""id"":""848"",""bonus"":""+30 Armor""},{""id"":""849"",""bonus"":""+3 Agility""},{""id"":""850"",""bonus"":""+35 Health""},{""id"":""4735"",""bonus"":""+5 Spirit""},{""id"":""724"",""bonus"":""+3 Stamina""},{""id"":""925"",""bonus"":""+3 Dodge""},{""id"":""4737"",""bonus"":""+5 Stamina""},{""id"":""4736"",""bonus"":""+5 Spirit""},{""id"":""856"",""bonus"":""+5 Strength""},{""id"":""857"",""bonus"":""+50 Mana""},{""id"":""4726"",""bonus"":""+3 Spirit""},{""id"":""863"",""bonus"":""+10 Parry""},{""id"":""865"",""bonus"":""+5 Skinning""},{""id"":""866"",""bonus"":""+2 All Stats""},{""id"":""884"",""bonus"":""+50 Armor""},{""id"":""4740"",""bonus"":""+5 Agility""},{""id"":""4738"",""bonus"":""+5 Stamina""},{""id"":""905"",""bonus"":""+5 Intellect""},{""id"":""852"",""bonus"":""+5 Stamina""},{""id"":""906"",""bonus"":""+5 Mining""},{""id"":""907"",""bonus"":""+7 Spirit""},{""id"":""908"",""bonus"":""+50 Health""},{""id"":""909"",""bonus"":""+5 Herbalism""},{""id"":""4734"",""bonus"":""+3 Agility""},{""id"":""4739"",""bonus"":""+5 Strength""},{""id"":""911"",""bonus"":""Minor Speed Increase""},{""id"":""4741"",""bonus"":""+7 Spirit""},{""id"":""913"",""bonus"":""+65 Mana""},{""id"":""923"",""bonus"":""+5 Dodge""},{""id"":""904"",""bonus"":""+5 Agility""},{""id"":""927"",""bonus"":""+7 Strength""},{""id"":""928"",""bonus"":""+3 All Stats""},{""id"":""4743"",""bonus"":""+7 Stamina""},{""id"":""930"",""bonus"":""+2% Mount Speed""},{""id"":""931"",""bonus"":""+10 Haste""},{""id"":""1883"",""bonus"":""+7 Intellect""},{""id"":""1884"",""bonus"":""+9 Spirit""},{""id"":""1885"",""bonus"":""+9 Strength""},{""id"":""1886"",""bonus"":""+9 Stamina""},{""id"":""1887"",""bonus"":""+7 Agility""},{""id"":""4742"",""bonus"":""+7 Strength""},{""id"":""1889"",""bonus"":""+70 Armor""},{""id"":""1890"",""bonus"":""+10 Spirit and +10 Stamina""},{""id"":""4744"",""bonus"":""+7 Stamina""},{""id"":""929"",""bonus"":""+7 Stamina""},{""id"":""851"",""bonus"":""+5 Spirit""},{""id"":""1892"",""bonus"":""+100 Health""},{""id"":""1893"",""bonus"":""+100 Mana""},{""id"":""2565"",""bonus"":""+9 Spirit""},{""id"":""2650"",""bonus"":""+15 Spell Power""},{""id"":""2613"",""bonus"":""+2% Threat""},{""id"":""2614"",""bonus"":""+20 Shadow Spell Power""},{""id"":""2615"",""bonus"":""+20 Frost Spell Power""},{""id"":""2616"",""bonus"":""+20 Fire Spell Power""},{""id"":""2617"",""bonus"":""+16 Spell Power""},{""id"":""910"",""bonus"":""+8 Agility and +8 Dodge""},{""id"":""2621"",""bonus"":""2% Reduced Threat""},{""id"":""3238"",""bonus"":""Gatherer""},{""id"":""3858"",""bonus"":""+10 Critical Strike""},{""id"":""4732"",""bonus"":""+5 Fishing""},{""id"":""3368"",""bonus"":""Rune of the Fallen Crusader""}]}";
        
        public BattleNetApiClient(string apiKey, string apiRegion)
        {
            _client = new WebClient();
            _apiKey = apiKey;
            _apiRegion = apiRegion;
        }
        
        public BattleNetApiClient()
            : this(ConfigurationManager.AppSettings["ApiKey"], ConfigurationManager.AppSettings["ApiRegion"])
        {
            
        }
        
        private string GetApiString(string apiPath)
        {
            return string.Format(_apiBase, _apiRegion, apiPath,_apiKey);
        }
        
        public PlayerModel GetCharacterProfile(string name, string server)
        {
            var apiPath = string.Format("character/{0}/{1}?fields=talents&locale=en_US", server, name);
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var character = str.ConvertJsonToObject<BattleNetCharacter>();
        
            var model = character.ToPlayerModel();
        
            return model;
        }
        
        public PlayerModel GetCharacterProfileAndItems(string name, string server)
        {
            var apiPath = string.Format("character/{0}/{1}?fields=talents,items&locale=en_US", server, name);
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var character = str.ConvertJsonToObject<BattleNetCharacter>();
        
            var model = character.ToPlayerModel();
        
            return model;
        }
        
        public Dictionary<string, int> GetClasses()
        {
            var apiPath = string.Format("data/character/classes?fields=items&locale=en_US");
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var model = str.ConvertJsonToObject<BattleNetClassList>();
        
            var dictionary = model.Classes.ToDictionary(c => c.Name, c => c.Id);
        
            return dictionary;
        }
        
        public Dictionary<string, int> GetRaces()
        {
            var apiPath = string.Format("data/character/races?fields=items&locale=en_US");
        
            var str = _client.DownloadString(GetApiString(apiPath));
        
            var model = str.ConvertJsonToObject<BattleNetRaceList>();
        
            var dictionary = model.Races.Distinct().ToDictionary(c => c.Side.UppercaseFirst() + c.Name, c => c.Id);
        
            return dictionary;
        }

        public IEnumerable<Enchant> GetEnchants()
        {
            var enchants = _enchantJson.ConvertJsonToObject<ParseEnchants>();

            return enchants.Enchants.Select(e => new Enchant() {Bonus = e.Bonus, Id = e.Id});
        }
    }
}