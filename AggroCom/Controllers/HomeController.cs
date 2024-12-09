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
      private readonly IProductOneTableOneOrchestrationService productOneTableOneOrchestrationService;

        public HomeController(IProductOneTableOneOrchestrationService productOneTableOneOrchestrationService)
        {
            this.productOneTableOneOrchestrationService = productOneTableOneOrchestrationService;
        }

        [HttpGet("with-students")]
        public async Task<IActionResult> GetAllGroupsWithStudentsAsync()
        {
            IQueryable<ProductOneTableOne> groupStudents = await this.productOneTableOneOrchestrationService.RetrieveAllProductOnesWithTableOnessAsync();
            return Ok(groupStudents);
        }
    }
}
