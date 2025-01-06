// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Brokers.Storages;
using AggroCom.Models.Foundations.Katalogs;
using AggroCom.Models.Foundations.News;
using AggroCom.Services.Foundations.Katalogs;
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
    public class FilesController:RESTFulController
    {
        private readonly IStorageBroker storageBroker; 
        private readonly IWebHostEnvironment environment;
        private readonly IKatalogService katalogService;

        public FilesController(
            IStorageBroker storageBroker,
            IWebHostEnvironment environment, 
            IKatalogService katalogService)
        {
            this.storageBroker = storageBroker;
            this.environment = environment;
            this.katalogService = katalogService;
        }

        [HttpPost("upload")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile(IFormFile picture, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Main file not found or empty.");
            }

            if (picture == null || picture.Length == 0)
            {
                return BadRequest("Picture file not found or empty.");
            }

            // Save main file to wwwroot/files
            var filePath = Path.Combine(this.environment.WebRootPath, "files");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var mainFilePath = Path.Combine(filePath, file.FileName);
            using (var stream = new FileStream(mainFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Save picture to wwwroot/images
            var imagePath = Path.Combine(this.environment.WebRootPath, "images");
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            var pictureFilePath = Path.Combine(imagePath, picture.FileName);
            using (var stream = new FileStream(pictureFilePath, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }

            // Create file metadata record
            var fileRecord = new Katalog
            {
                FileName = file.FileName,
                FilePath = $"/files/{file.FileName}", // Path for accessing the main file
                FilePicture = $"/images/{picture.FileName}", // Path for accessing the picture
                FileSize = file.Length
            };

            // Save metadata to the database asynchronously
            await this.storageBroker.InsertKatalogAsync(fileRecord);

            // Return the result with Created status
            return Created(fileRecord);
        }



        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var files = await this.storageBroker.SelectAllKatalogsAsync();
            return Ok(files);
        }


        [HttpDelete("{Id}")]
        public async ValueTask<ActionResult<Katalog>> DeleteKatalogByIdAsync(int Id)
        {
            try
            {
                return await this.katalogService.RemoveKatalogAsync(Id);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
