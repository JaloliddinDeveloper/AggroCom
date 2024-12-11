using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.ProductOnes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.IO;
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
                if (picture != null && picture.Length > 0)
                {
                    string uploadsFolder = Path.Combine(this.webHostEnvironment.WebRootPath, "images");
                    Directory.CreateDirectory(uploadsFolder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await picture.CopyToAsync(fileStream);
                    }

                    productOne.ProductPicture = $"images/{fileName}";
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

                ProductOne addedProductOne = await this.productOneService.AddProductOneAsync(addProductOne);

                return Created(addedProductOne);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
