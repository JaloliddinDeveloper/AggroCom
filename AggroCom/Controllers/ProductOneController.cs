using AggroCom.Brokers.Storages;
using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.ProductOnes;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Threading.Tasks;

namespace AggroCom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductOneController : RESTFulController
    {
       private readonly IProductOneService productOneService;

        public ProductOneController(IProductOneService productOneService)
        {
            this.productOneService = productOneService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ProductOne>> PostProductOneAsync(ProductOne ProductOne)
        {
            try
            {
                ProductOne addProductOne = new ProductOne
                {
                    Id = ProductOne.Id,
                    Name = ProductOne.Name,
                };

                return await this.productOneService.AddProductOneAsync(addProductOne);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
