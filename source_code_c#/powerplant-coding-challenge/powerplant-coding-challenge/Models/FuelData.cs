using System;
using System.Text.Json.Serialization;

namespace powerplant_coding_challenge.Models
{
	public class FuelData
	{
        [JsonPropertyName("gas(euro/MWh)")]
        public double GasPrice { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public double KerosinePrice { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public double CO2Price { get; set; }

        [JsonPropertyName("wind(%)")]
        public double WindPercentage { get; set; }
	}
}

