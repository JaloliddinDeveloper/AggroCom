using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Models.Orchestrations;
using AggroCom.Services.Foundations.ProductOnes;
using AggroCom.Services.Foundations.TableOnes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices
{
    public class ProductOneTableOneOrchestrationService: IProductOneTableOneOrchestrationService
    {
        private readonly IProductOneService productOneService;
        private readonly ITableOneService tableOneService;

        public ProductOneTableOneOrchestrationService(
            IProductOneService productOneService,
            ITableOneService tableOneService)
        {
            this.productOneService = productOneService;
            this.tableOneService = tableOneService;
        }

        public async ValueTask<IQueryable<ProductOneTableOne>> RetrieveAllProductOnesWithTableOnessAsync()
        {
            var groups = (await this.productOneService.RetrieveAllProductOnesAsync()).ToList();
            var students = (await this.tableOneService.RetrieveAllTableOnesAsync()).ToList();

            var groupStudents = groups.Select(group => new ProductOneTableOne
            {
                ProductOne = group,
                TableOnes = students.Where(student => student.ProductOneId == group.Id).ToList()
            });

            return groupStudents.AsQueryable();
        }
    }
}
