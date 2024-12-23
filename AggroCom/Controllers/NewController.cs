// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Brokers.Storages;
using AggroCom.Models.Foundations.News;
using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.News;
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
    public class NewController: RESTFulController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IStorageBroker storageBroker;
        private readonly INewsService newsService;

        public NewController(
            IWebHostEnvironment webHostEnvironment, 
            IStorageBroker storageBroker, 
            INewsService newsService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.storageBroker = storageBroker;
            this.newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPictureAsync([FromForm] New newModel, IFormFile newPicture)
        {
            try
            {
                if (newModel == null)
                    return BadRequest("New data is missing.");

                if (newPicture == null || newPicture.Length == 0)
                    return BadRequest("NewPicture is required.");

                string uploadsFolder = Path.Combine(this.webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(newPicture.FileName)}";
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newPicture.CopyToAsync(fileStream);
                }

                newModel.NewPicture = $"images/{fileName}";
                newModel.Date = DateTimeOffset.Now;

               await this.storageBroker.InsertNewAsync(newModel);

                return Created(newModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNewsSortedByDateAsync()
        {
            try
            {
                var allNewsQuery = await this.storageBroker.SelectAllNewsOrderAsync();

                var sortedNews = allNewsQuery.OrderByDescending(news => news.Date).ToList();

                return Ok(sortedNews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async ValueTask<ActionResult<New>> DeleteNewsByIdAsync(int Id)
        {
            try
            {
                return await this.newsService.RemoveNewsAsync(Id);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
