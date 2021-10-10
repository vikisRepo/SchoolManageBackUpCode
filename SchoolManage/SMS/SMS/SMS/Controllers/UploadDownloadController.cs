using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadDownloadController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly MysqlDataContext _dbcontext;

        public UploadDownloadController(IWebHostEnvironment environment, MysqlDataContext dbcontext)
        {
            _hostingEnvironment = environment;
            this._dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("UploadStudentDocument")]
        public async Task<IActionResult> UploadStudentDocument(IFormFile file, [FromForm]  StudentAttachments studentAttachments)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                studentAttachments.PathToFile = filePath;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                await _dbcontext.StudentDocuments.AddAsync(studentAttachments);
                await _dbcontext.SaveChangesAsync();

            }
            return Ok();
        }

    [HttpGet]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, file);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), file);
        }

        [HttpGet]
        [Route("downloadStudentDocument")]
        public async Task<IActionResult> DownloadStudentDocument([FromBody] StudentAttachments studentAttachments)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, studentAttachments.PathToFile);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), studentAttachments.PathToFile);
        }

        [HttpGet]
        [Route("GetStudentDocumentDetails/{admissionNumber}/{docType}")]
        public IActionResult GetStudentDocumentDetails(int admissionNumber, string docType )
        {
            return Ok(_dbcontext.StudentDocuments.Where(x => x.AdmissionNumber == admissionNumber 
                      && x.DocumentType == docType).FirstOrDefault());

        }

        [HttpGet]
        [Route("files")]
        public IActionResult Files()
        {
            var result = new List<string>();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (Directory.Exists(uploads))
            {
                var provider = _hostingEnvironment.ContentRootFileProvider;
                foreach (string fileName in Directory.GetFiles(uploads))
                {
                    var fileInfo = provider.GetFileInfo(fileName);
                    result.Add(fileInfo.Name);
                }
            }
            return Ok(result);
        }


        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
