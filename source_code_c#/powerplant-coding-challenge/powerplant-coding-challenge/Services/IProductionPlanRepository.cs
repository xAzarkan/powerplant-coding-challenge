using System;
using powerplant_coding_challenge.Models;
namespace powerplant_coding_challenge.Services
{
	public interface IProductionPlanRepository
	{
		public List<ProductionPlanResponse> CreateProductionPlan(ProductionPlan productionPlan);
	}
}

