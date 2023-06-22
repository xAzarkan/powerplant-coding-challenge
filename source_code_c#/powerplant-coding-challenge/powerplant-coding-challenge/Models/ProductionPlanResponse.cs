using System;
using System.Text.Json.Serialization;

namespace powerplant_coding_challenge.Models
{
	public class ProductionPlanResponse
	{
		public string Name { get; set; }

        [JsonPropertyName("p")]
        public double Power { get; set; }
	}
}

