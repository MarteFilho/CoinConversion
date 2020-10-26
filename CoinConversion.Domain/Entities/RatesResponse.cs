using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinConversion.Domain.Entities
{
    public class RatesResponse
    {

        [JsonProperty("rates")]
        public Dictionary<string, decimal> Values { get; set; }
    }
}