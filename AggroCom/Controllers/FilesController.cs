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
        private readonly IKatalogService katalogService;
        private readonly string uploadsFolder = "/var/www/files";

        public FilesController(
            IStorageBroker storageBroker,
            IKatalogService katalogService)
        {
            this.storageBroker = storageBroker;
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

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var mainFilePath = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(mainFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var pictureFilePath = Path.Combine(uploadsFolder, picture.FileName);
            using (var stream = new FileStream(pictureFilePath, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }

            var fileRecord = new Katalog
            {
                FileName = file.FileName,
                FilePath = $"/files/{file.FileName}", 
                FilePicture = $"/files/{picture.FileName}", 
                FileSize = file.Length
            };

            await this.storageBroker.InsertKatalogAsync(fileRecord);

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
