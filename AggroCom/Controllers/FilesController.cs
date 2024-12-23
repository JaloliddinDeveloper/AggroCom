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
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Fayl topilmadi yoki bo'sh.");
            }

            // Faylni saqlash yo'li
            var uploadPath = Path.Combine(this.environment.WebRootPath, "files");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Fayl metadata'sini bazaga yozish
            var fileRecord = new Katalog
            {
                FileName = file.FileName,
                FilePath = $"/files/{file.FileName}",
                FileSize = file.Length
            };

            // Asynchronous saqlash
            await this.storageBroker.InsertKatalogAsync(fileRecord);

            // Natijani Created statusida qaytarish
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
