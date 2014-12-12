using System;
using Newtonsoft.Json;

namespace BattleNetApi.JSON
{
    public class BattleNetRace : IEquatable<BattleNetRace>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mask")]
        public int Mask { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public bool Equals(BattleNetRace other)
        {
            if (other == null)
            {
                return false;
            }
            if (other.Id == Id)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null.
            int hashProductName = Name == null ? 0 : Name.GetHashCode();

            //Get hash code for the Id field.
            int hashProductCode = Id.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }
    }
}