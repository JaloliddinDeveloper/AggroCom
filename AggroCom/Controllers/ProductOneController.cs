// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.ProductOnes;
using AggroCom.Services.Processings.ProductOnes;
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
        private readonly IProductOneProcessingService productOneProcessingService;

        public ProductOneController(
            IProductOneService productOneService,
            IWebHostEnvironment webHostEnvironment,
            IProductOneProcessingService productOneProcessingService)
        {
            this.productOneService = productOneService;
            this.webHostEnvironment = webHostEnvironment;
            this.productOneProcessingService = productOneProcessingService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ProductOne>> PostProductOneAsync([FromForm] ProductOne productOne, IFormFile picture, IFormFile icon)
        {
            try
            {
                if (productOne == null) return BadRequest("Product data is missing.");

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                if (picture != null && picture.Length > 0)
                {
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
                    return BadRequest("Product picture is required.");
                }

                if (icon != null && icon.Length > 0)
                {
                    string iconFileName = $"{Guid.NewGuid()}{Path.GetExtension(icon.FileName)}";
                    string iconFilePath = Path.Combine(uploadsFolder, iconFileName);

                    using (var iconStream = new FileStream(iconFilePath, FileMode.Create))
                    {
                        await icon.CopyToAsync(iconStream);
                    }

                    productOne.IconUrl = $"images/{iconFileName}";
                }
                else
                {
                    return BadRequest("Icon is required.");
                }

                ProductOne addProductOne = new ProductOne
                {
                    Id = productOne.Id,
                    TitleUz = productOne.TitleUz,
                    TitleRu = productOne.TitleRu,
                    DesUz = productOne.DesUz,
                    DesRu = productOne.DesRu,
                    DescriptionUz = productOne.DescriptionUz,
                    DescriptionRu = productOne.DescriptionRu,
                    TasirModdaUz = productOne.TasirModdaUz,
                    TasirModdaRu = productOne.TasirModdaRu,
                    KimyoviySinfiUz = productOne.KimyoviySinfiUz,
                    KimyoviySinfiRu = productOne.KimyoviySinfiRu,
                    PreparatShakliUz = productOne.PreparatShakliUz,
                    PreparatShakliRu = productOne.PreparatShakliRu,
                    QadogiUz = productOne.QadogiUz,
                    QadogiRu = productOne.QadogiRu,
                    ProductPicture = productOne.ProductPicture,
                    IconUrl = productOne.IconUrl,
                    ProductType = productOne.ProductType,
                    AdditionUz = productOne.AdditionUz,
                    AdditionRu = productOne.AdditionRu
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
            try
            {
                var products = await productOneService.RetrieveAllProductOnesAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOne>> GetProductOneById(int id)
        {
            try
            {
                var product = await productOneService.RetrieveProductOneByIdAsync(id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                return Ok(product);
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

        [HttpGet("Gerbitsids")]
        public async Task<IActionResult> GetGerbitsidsAsync()
        {
            try
            {
                var gerbiseds = await this.productOneProcessingService.RetrieveAllProductOnesGepbisetsAsync();

                return Ok(gerbiseds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Fungitsids")]
        public async Task<IActionResult> GetFungitsidsAsync()
        {
            try
            {
                var fungicidlar = await this.productOneProcessingService.
                    RetrieveAllProductOnesFungisetsAsync();

                return Ok(fungicidlar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
