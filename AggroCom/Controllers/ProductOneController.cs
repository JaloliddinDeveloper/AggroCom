using AggroCom.Brokers.Storages;
using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.ProductOnes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductOneController : RESTFulController
    {
        private readonly IProductOneService productOneService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductOneController(
            IProductOneService productOneService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.productOneService = productOneService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ProductOne>> PostProductOneAsync([FromForm] ProductOne productOne, IFormFile picture)
        {
            try
            {
                if (productOne == null) return BadRequest("Product data is missing.");

                if (picture != null && picture.Length > 0)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(picture.FileName)}";
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await picture.CopyToAsync(fileStream);
                    }

                    productOne.ProductPicture = $"images/{fileName}";
                }
                else
                {
                    return BadRequest("Picture is required.");
                }

                ProductOne addProductOne = new ProductOne
                {
                    Id = productOne.Id,
                    Title = productOne.Title,
                    Description = productOne.Description,
                    TasirModda = productOne.TasirModda,
                    KimyoviySinfi = productOne.KimyoviySinfi,
                    PreparatShakli = productOne.PreparatShakli,
                    Qadogi = productOne.Qadogi,
                    ProductPicture = productOne.ProductPicture,
                    ProductType = productOne.ProductType,
                };

                ProductOne addedProductOne = await productOneService.AddProductOneAsync(addProductOne);

                return Created(addedProductOne);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<ProductOne>>> GetAllProductOnes()
        {
            var products = await productOneService.RetrieveAllProductOnesAsync();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOne>> GetProductOneById(int id)
        {
            var product = await productOneService.RetrieveProductOneByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok(product);
        }


        [HttpDelete("{productOneId}")]
        public async ValueTask<ActionResult<ProductOne>> DeleteProductOneByIdAsync(int productOneId)
        {
            try
            {
                return await this.productOneService.RemoveProductOneAsync(productOneId);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
