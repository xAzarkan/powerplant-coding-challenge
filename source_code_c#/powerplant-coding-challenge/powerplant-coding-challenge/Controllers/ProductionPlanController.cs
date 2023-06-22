using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using powerplant_coding_challenge.Models;
using powerplant_coding_challenge.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace powerplant_coding_challenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IProductionPlanRepository productionPlanRepository;

        public ProductionPlanController(IProductionPlanRepository _productionPlanRepository)
        {
            productionPlanRepository = _productionPlanRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductionPlan))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateProductionPlan([FromBody] ProductionPlan productionPlan)
        {
            if (productionPlan == null)
            {
                return BadRequest("Invalid payload");
            }

            List<ProductionPlanResponse> responses = productionPlanRepository.CreateProductionPlan(productionPlan);

            if (responses == null)
            {
                return BadRequest("Failed to generate production plan");
            }

            return CreatedAtAction(nameof(CreateProductionPlan), responses);
        }
    }
}

