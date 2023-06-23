using System;
using powerplant_coding_challenge.Models;

namespace powerplant_coding_challenge.Services
{
    public class ProductionPlanRepository : IProductionPlanRepository
    {
        public List<ProductionPlanResponse> CreateProductionPlan(ProductionPlan productionPlan)
        {
            List<ProductionPlanResponse> responses = new List<ProductionPlanResponse>();

            List<Powerplant> gasFiredPowerplants = new List<Powerplant>();
            List<Powerplant> turbojetPowerplants = new List<Powerplant>();

            double remainingLoad = productionPlan.Load;

            foreach (Powerplant powerplant in productionPlan.Powerplants)
            {

                if (powerplant.Type.Equals("gasfired"))
                {
                    gasFiredPowerplants.Add(powerplant);
                }
                else if (powerplant.Type.Equals("windturbine"))
                {
                    // No cost, so we can switch it on directly
                    double powerProduced = powerplant.PMax * (productionPlan.Fuels.WindPercentage / 100);
                    remainingLoad -= powerProduced;
                    responses.Add(new ProductionPlanResponse { Name = powerplant.Name, Power = Math.Round(powerProduced, 1) });
                }
                else if (powerplant.Type.Equals("turbojet"))
                {
                    turbojetPowerplants.Add(powerplant);
                }
            }

            // Merit-order
            gasFiredPowerplants = gasFiredPowerplants.OrderByDescending(p => p.Efficiency).ToList();
            turbojetPowerplants = turbojetPowerplants.OrderByDescending(p => p.Efficiency).ToList();

            // Activating gasfired powerplants according to the merit-order until there is no more remaining load
            foreach (Powerplant gasFiredPowerplant in gasFiredPowerplants)
            {
                if(remainingLoad > 0)
                {
                    double powerProduced = Math.Min(remainingLoad, gasFiredPowerplant.PMax);
                    responses.Add(new ProductionPlanResponse { Name = gasFiredPowerplant.Name, Power = Math.Round(powerProduced, 1) });

                    remainingLoad -= powerProduced;
                }
                else
                {
                    responses.Add(new ProductionPlanResponse { Name = gasFiredPowerplant.Name, Power = Math.Round(remainingLoad, 1) });
                }
            }

            // Activating turbojet powerplants according to the merit-order until there is no more remaining load
            foreach (Powerplant turbojetPowerplant in turbojetPowerplants)
            {
                if (remainingLoad > 0)
                {
                    double powerProduced = Math.Min(remainingLoad, turbojetPowerplant.PMax);
                    responses.Add(new ProductionPlanResponse { Name = turbojetPowerplant.Name, Power = Math.Round(powerProduced, 1) });

                    remainingLoad -= powerProduced;
                }
                else
                {
                    responses.Add(new ProductionPlanResponse { Name = turbojetPowerplant.Name, Power = Math.Round(remainingLoad, 1) });
                }
            }

            return responses;
        }

    }
}

