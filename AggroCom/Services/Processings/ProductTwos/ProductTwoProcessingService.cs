// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.ProductTwos;
using AggroCom.Services.Foundations.ProductTwos;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Services.Processings.ProductTwos
{
    public class ProductTwoProcessingService : IProductTwoProcessingService
    {
        private readonly IProductTwoService productTwoService;

        public ProductTwoProcessingService(IProductTwoService productTwoService)=>
            this.productTwoService = productTwoService;

        public async ValueTask<IQueryable<ProductTwo>> RetrieveAllProductTwosSuyuqAsync()=>
             (await this.productTwoService.RetrieveAllProductTwosAsync())
                    .Where(product => product.ProductTwoType == ProductTwoType.Суюқ);

        public async ValueTask<IQueryable<ProductTwo>> RetrieveAllProductTwosKukunAsync()=>
             (await this.productTwoService.RetrieveAllProductTwosAsync())
                    .Where(product => product.ProductTwoType == ProductTwoType.Кукун);
    }
}
