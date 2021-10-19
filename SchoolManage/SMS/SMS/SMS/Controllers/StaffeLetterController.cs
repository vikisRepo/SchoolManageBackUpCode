using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffeLetterController : ControllerBase
	{
		private IWebHostEnvironment _hostingEnvironment;
		private readonly MysqlDataContext _dbcontext;
		public StaffeLetterController(IWebHostEnvironment environment, MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
			_hostingEnvironment = environment;
		}
		// GET: api/<StaffeLetterController>
		[HttpGet]
		public IEnumerable<StaffeLetter> Get()
		{
			return _dbcontext.StaffeLetters.ToList();
		}

		// GET api/<StaffeLetterController>/5
		[HttpGet("{id}")]
		public StaffeLetter Get(string id)
		{
			return _dbcontext.StaffeLetters.Where(X => X.Empid == id).FirstOrDefault();
		}

		[HttpPost]
		[Route("UploadStaffeLetterAndDocument")]
		public async Task<IActionResult> UploadStaffeLetterAndDocument(IFormFile file, [FromForm] StaffeLetter staffeLetterback)
		{
			if (file != null)
			{
				var staffAttachments = new StaffAttachments();
				staffAttachments.EmployeeId = staffeLetterback.Empid;
				staffAttachments.DocumentType = "Staff Feedback";
				var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
				if (!Directory.Exists(uploads))
				{
					Directory.CreateDirectory(uploads);
				}
				if (file.Length > 0)
				{
					var filePath = Path.Combine(uploads, file.FileName);
					staffAttachments.PathToFile = filePath;
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await file.CopyToAsync(fileStream);
					}

					_dbcontext.StaffDocuments.Add(staffAttachments);
					_dbcontext.SaveChanges();

					staffeLetterback.AttachmentId = staffAttachments.StaffAttachmentsId;


				}
			}
			await _dbcontext.StaffeLetters.AddAsync(staffeLetterback);
			await _dbcontext.SaveChangesAsync();
			return Ok();
		}

		// POST api/<StaffeLetterController>
		[HttpPost]
		public void Post([FromBody] StaffeLetter staffeLetter)
		{
			staffeLetter.AttachmentId = 0;
			_dbcontext.StaffeLetters.Add(staffeLetter);
			_dbcontext.SaveChanges();
		}

		// PUT api/<StaffeLetterController>/5
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] StaffeLetter staffeLetter)
		{
			_dbcontext.Entry(_dbcontext.StaffeLetters.Where(X => X.Empid == id).FirstOrDefault()).CurrentValues.SetValues(staffeLetter);
			_dbcontext.SaveChanges();
		}

		// DELETE api/<StaffeLetterController>/5
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_dbcontext.Remove(_dbcontext.StaffeLetters.Where(X => X.Empid == id).FirstOrDefault());
			_dbcontext.SaveChanges();
		}
	}
}
