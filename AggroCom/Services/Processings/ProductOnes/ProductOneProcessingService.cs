using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.ProductOnes;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Services.Processings.ProductOnes
{
    public class ProductOneProcessingService: IProductOneProcessingService
    {
        private readonly IProductOneService productOneService;

        public ProductOneProcessingService(
            IProductOneService productOneService)
        {
            this.productOneService = productOneService;
        }

        public async ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesGepbisetsAsync() =>
             (await this.productOneService.RetrieveAllProductOnesAsync())
                    .Where(product => product.ProductType == ProductType.Гербицидлар);

        public async ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesFungisetsAsync() =>
            (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(product => product.ProductType == ProductType.Фунгицидлар);
    }
}
