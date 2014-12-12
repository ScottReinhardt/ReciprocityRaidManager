using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetWeaponInfo
    {
        [JsonProperty("damage")]
        public BattleNetWeaponDamage Damage { get; set; }

        [JsonProperty("weaponSpeed")]
        public double WeaponSpeed { get; set; }

        [JsonProperty("dps")]
        public double Dps { get; set; }
    }
}