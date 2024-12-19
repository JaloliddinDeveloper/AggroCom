// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Threading.Tasks;

namespace AggroCom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : RESTFulController
    {
      private readonly IProductOneTableOneOrchestrationService 
            productOneTableOneOrchestrationService;

        public HomeController(
            IProductOneTableOneOrchestrationService productOneTableOneOrchestrationService)
        {
            this.productOneTableOneOrchestrationService = productOneTableOneOrchestrationService;
        }

        [HttpGet("details/{productId}")]
        public async Task<IActionResult> GetProductOneTableOneByIdAsync(int productId)
        {
            try
            {
                var product = await this.productOneTableOneOrchestrationService
                    .RetrieveProductOneTableOneByIdAsync(productId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
