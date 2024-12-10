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

        public async ValueTask<IQueryable<ProductOneTableOne>> RetrieveProductOnesHerbicidesWithTableOnesAsync()
        {
            var products = (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(p => p.ProductType == ProductType.Гербицидлар).ToList();

            var tableOnes = (await this.tableOneService.RetrieveAllTableOnesAsync()).ToList();

            var result = products.Select(product => new ProductOneTableOne
            {
                ProductOne = product,
                TableOnes = tableOnes.Where(t => t.ProductOneId == product.Id).ToList()
            });

            return result.AsQueryable();
        }

        public async ValueTask<IQueryable<ProductOneTableOne>> RetrieveProductOnesFungicidesWithTableOnesAsync()
        {
            var products = (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(p => p.ProductType == ProductType.Фунгицидлар).ToList();

            var tableOnes = (await this.tableOneService.RetrieveAllTableOnesAsync()).ToList();

            var result = products.Select(product => new ProductOneTableOne
            {
                ProductOne = product,
                TableOnes = tableOnes.Where(t => t.ProductOneId == product.Id).ToList()
            });

            return result.AsQueryable();
        }

    }
}
