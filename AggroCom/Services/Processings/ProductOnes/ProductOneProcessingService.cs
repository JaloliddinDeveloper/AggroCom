// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.ProductOnes;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Services.Processings.ProductOnes
{
    public class ProductOneProcessingService : IProductOneProcessingService
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

        public async ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesInsektorsAsync() =>
            (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(product => product.ProductType == ProductType.Инсектоакарацидлар);

        public async ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesDefolsAsync() =>
            (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(product => product.ProductType == ProductType.Дефолиантлар);

        public async ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesSirtFaolsAsync() =>
            (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(product => product.ProductType == ProductType.Сиртфаолмодда);

        public async ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesUrugdorisAsync() =>
            (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(product => product.ProductType == ProductType.Уруғдорилагичлар);

        public async ValueTask<IQueryable<ProductOne>> RetrieveAllProductOsimlikPresAsync() =>
            (await this.productOneService.RetrieveAllProductOnesAsync())
                .Where(product => product.ProductType == ProductType.Ўсимликларнипрепаратлар);
    }
}
