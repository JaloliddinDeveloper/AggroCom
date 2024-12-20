// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.ProductTwos;
using AggroCom.Services.Foundations.ProductTwos;
using AggroCom.Services.Processings.ProductTwos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using AggroCom.Services.Orchestrations.ProductTwoTableTwoOrchestrations;

namespace AggroCom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTwoController : RESTFulController
    {
        private readonly IProductTwoService ProductTwoService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductTwoProcessingService ProductTwoProcessingService;
        private readonly IProductTwoTableTwoOrchestrationService
            productTwoTableTwoOrchestrationService;

        public ProductTwoController(
            IProductTwoService productTwoService, 
            IWebHostEnvironment webHostEnvironment, 
            IProductTwoProcessingService productTwoProcessingService,
            IProductTwoTableTwoOrchestrationService 
            productTwoTableTwoOrchestrationService)
        {
            ProductTwoService = productTwoService;
            this.webHostEnvironment = webHostEnvironment;
            ProductTwoProcessingService = productTwoProcessingService;
            this.productTwoTableTwoOrchestrationService = 
                productTwoTableTwoOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ProductTwo>> PostProductTwoAsync([FromForm] ProductTwo ProductTwo, IFormFile picture, IFormFile icon)
        {
            try
            {
                if (ProductTwo == null) return BadRequest("Product data is missing.");

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

                    ProductTwo.ProductPicture = $"images/{fileName}";
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

                    ProductTwo.ProductIcon = $"images/{iconFileName}";
                }
                else
                {
                    return BadRequest("Icon is required.");
                }

                ProductTwo addProductTwo = new ProductTwo
                {
                    Id = ProductTwo.Id,
                    Name = ProductTwo.Name,
                    Des = ProductTwo.Des,
                    Description = ProductTwo.Description,
                    ProductIcon = ProductTwo.ProductIcon,
                    ProductTwoType = ProductTwo.ProductTwoType,
                    ProductPicture = ProductTwo.ProductPicture,
                };

                ProductTwo addedProductTwo = await ProductTwoService.AddProductTwoAsync(addProductTwo);

                return Created(addedProductTwo);
            }

            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<ProductTwo>>> GetAllProductTwos()
        {
            try
            {
                var products = await ProductTwoService.RetrieveAllProductTwosAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTwo>> GetProductTwoById(int id)
        {
            try
            {
                var product = await ProductTwoService.RetrieveProductTwoByIdAsync(id);
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

        [HttpDelete("{ProductTwoId}")]
        public async ValueTask<ActionResult<ProductTwo>> DeleteProductTwoByIdAsync(int ProductTwoId)
        {
            try
            {
                return await this.ProductTwoService.RemoveProductTwoAsync(ProductTwoId);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("details/{productId}")]
        public async Task<IActionResult> GetProductTwoTableOneByIdAsync(int productId)
        {
            try
            {
                var product = await this.productTwoTableTwoOrchestrationService
                    .RetrieveProductTwoTableTwoByIdAsync(productId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Suyuq")]
        public async Task<IActionResult> GetSuyuqAsync()
        {
            try
            {
                var gerbiseds = await this.ProductTwoProcessingService.RetrieveAllProductTwosSuyuqAsync();

                return Ok(gerbiseds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Kukun")]
        public async Task<IActionResult> GetFungitsidsAsync()
        {
            try
            {
                var fungicidlar = await this.ProductTwoProcessingService.
                    RetrieveAllProductTwosKukunAsync();

                return Ok(fungicidlar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
