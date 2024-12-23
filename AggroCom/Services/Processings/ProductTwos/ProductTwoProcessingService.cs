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

        public async ValueTask<IQueryable<ProductTwo>> RetrieveAllProductTwosБиостимуляторAsync()=>
             (await this.productTwoService.RetrieveAllProductTwosAsync())
                    .Where(product => product.ProductTwoType == ProductTwoType.Биостимулятор);

        public async ValueTask<IQueryable<ProductTwo>> RetrieveAllProductTwosМикроэлементAsync() =>
             (await this.productTwoService.RetrieveAllProductTwosAsync())
                    .Where(product => product.ProductTwoType == ProductTwoType.Микроэлемент); 
        
        public async ValueTask<IQueryable<ProductTwo>> RetrieveAllProductTwosНпкAsync() =>
             (await this.productTwoService.RetrieveAllProductTwosAsync())
                    .Where(product => product.ProductTwoType == ProductTwoType.Нпк);
    }
}
