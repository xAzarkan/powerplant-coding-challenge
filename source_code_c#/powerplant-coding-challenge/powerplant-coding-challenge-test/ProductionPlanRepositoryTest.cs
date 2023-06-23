using System;
using powerplant_coding_challenge.Models;
using powerplant_coding_challenge.Services;

namespace powerplant_coding_challenge_test
{
	public class ProductionPlanRepositoryTest
	{
		[Fact]
        public void CreateProductionPlan_ReturnsCorrectResponse()
        {
            var repository = new ProductionPlanRepository();
            var productionPlan = new ProductionPlan
            {
                Load = 100,
                Powerplants = new List<Powerplant>
                {
                    new Powerplant { Name = "GasPlant1", Type = "gasfired", PMax = 50, Efficiency = 0.7 },
                    new Powerplant { Name = "GasPlant2", Type = "gasfired", PMax = 40, Efficiency = 0.6 },
                    new Powerplant { Name = "Turbojet1", Type = "turbojet", PMax = 30, Efficiency = 0.5 }
                },
                Fuels = new FuelData { GasPrice = 13.5, KerosinePrice = 50, CO2Price = 20, WindPercentage = 20 }
            };

            // Act
            var result = repository.CreateProductionPlan(productionPlan);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

            Assert.Equal("GasPlant1", result[0].Name);
            Assert.Equal(50, result[0].Power);

            Assert.Equal("GasPlant2", result[1].Name);
            Assert.Equal(40, result[1].Power);

            Assert.Equal("Turbojet1", result[2].Name);
            Assert.Equal(10, result[2].Power);
        }
	}
}