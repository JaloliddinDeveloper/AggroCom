using AggroCom.Models.Orchestrations;
using AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System.Linq;
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

        [HttpGet("ger")]
        public async Task<IActionResult> GetHerbicidesWithTableOnes()
        {
            IQueryable<ProductOneTableOne> groupStudents = 
                await this.productOneTableOneOrchestrationService.
                RetrieveProductOnesHerbicidesWithTableOnesAsync();

            return Ok(groupStudents);
        }

        [HttpGet("fun")]
        public async Task<IActionResult> GetFungicidesWithTableOnes()
        {
            IQueryable<ProductOneTableOne> groupStudents = 
                await this.productOneTableOneOrchestrationService.
                RetrieveProductOnesFungicidesWithTableOnesAsync();

            return Ok(groupStudents);
        }
    }
}
