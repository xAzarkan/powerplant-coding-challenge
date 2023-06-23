using System;
using System.Text.Json.Serialization;

namespace powerplant_coding_challenge.Models
{
	public class Powerplant
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public double Efficiency { get; set; }

        [JsonPropertyName("pmin")]
        public double PMin { get; set; }

        [JsonPropertyName("pmax")]
        public double PMax { get; set; }
    }
}

