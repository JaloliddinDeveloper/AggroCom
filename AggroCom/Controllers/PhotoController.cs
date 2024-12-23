// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Brokers.Storages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System.IO;
using System.Threading.Tasks;
using System;
using AggroCom.Services.Foundations.Photos;
using AggroCom.Models.Foundations.Photos;
using System.Linq;

namespace AggroCom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController:RESTFulController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IStorageBroker storageBroker;
        private readonly IPhotoService  photoService;

        public PhotoController(
            IWebHostEnvironment webHostEnvironment, 
            IStorageBroker storageBroker, 
            IPhotoService photoService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.storageBroker = storageBroker;
            this.photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPictureAsync([FromForm] Photo newModel, IFormFile newPicture)
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

                newModel.PictureUrl = $"images/{fileName}";
                newModel.CreateDate = DateTimeOffset.Now;

                await this.storageBroker.InsertPhotoAsync(newModel);

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
                var allNewsQuery = await this.storageBroker.SelectAllPhotosAsync();

                var sortedNews = allNewsQuery.OrderByDescending(news => news.CreateDate).ToList();

                return Ok(sortedNews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async ValueTask<ActionResult<Photo>> DeletePhotoByIdAsync(int Id)
        {
            try
            {
                return await this.photoService.RemovePhotoAsync(Id);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
