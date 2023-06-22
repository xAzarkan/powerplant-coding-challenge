using System;
namespace powerplant_coding_challenge.Models
{
	public class ProductionPlan
	{
		public double Load { get; set; }
		public FuelData Fuels { get; set; }
		public List<Powerplant> Powerplants { get; set; }
    }
}

