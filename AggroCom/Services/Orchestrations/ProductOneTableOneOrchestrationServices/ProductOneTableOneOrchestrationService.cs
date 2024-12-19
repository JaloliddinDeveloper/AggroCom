using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Models.Orchestrations.ProductOnes;
using AggroCom.Services.Foundations.ProductOnes;
using AggroCom.Services.Foundations.TableOnes;
using System;
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

        public async ValueTask<ProductOneTableOne> RetrieveProductOneTableOneByIdAsync(int productId)
        {
            var product = (await this.productOneService.RetrieveAllProductOnesAsync())
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return null;
            }

            var tableOnes = (await this.tableOneService.RetrieveAllTableOnesAsync())
                .Where(t => t.ProductOneId == product.Id).ToList();

            return new ProductOneTableOne
            {
                ProductOne = product,
                TableOnes = tableOnes
            };
        }
    }
}
