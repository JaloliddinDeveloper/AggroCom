// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Brokers.Storages;
using AggroCom.Models.Foundations.Katalogs;
using AggroCom.Services.Foundations.Katalogs;
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
    public class FilesController : RESTFulController
    {
        private readonly IStorageBroker storageBroker;
        private readonly IKatalogService katalogService;
        private readonly string uploadsFolder = "/var/www/files"; 
        private readonly string baseUrl = "http://165.232.173.157"; 

        public FilesController(
            IStorageBroker storageBroker,
            IKatalogService katalogService)
        {
            this.storageBroker = storageBroker;
            this.katalogService = katalogService;
        }

        [HttpPost("upload")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile(IFormFile picture, IFormFile file, string nameUz, string nameRu)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Main file not found or empty.");
            }

            if (picture == null || picture.Length == 0)
            {
                return BadRequest("Picture file not found or empty.");
            }

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            try
            {
                string fileGuid = Guid.NewGuid().ToString();
                string pictureGuid = Guid.NewGuid().ToString();

                string fileExtension = Path.GetExtension(file.FileName);
                string pictureExtension = Path.GetExtension(picture.FileName);

                var mainFilePath = Path.Combine(uploadsFolder, fileGuid + fileExtension);
                var pictureFilePath = Path.Combine(uploadsFolder, pictureGuid + pictureExtension);

                using (var stream = new FileStream(mainFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var stream = new FileStream(pictureFilePath, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                var fileRecord = new Katalog
                {
                    FileName = fileGuid + fileExtension,
                    FilePath = $"{baseUrl}/files/{fileGuid + fileExtension}", 
                    FilePicture = $"{baseUrl}/files/{pictureGuid + pictureExtension}", 
                    FileSize = file.Length,
                    NameUz = nameUz, 
                    NameRu = nameRu  
                };

                await this.storageBroker.InsertKatalogAsync(fileRecord);

                return Created(fileRecord.FilePath, fileRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while processing the files.");
            }
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
