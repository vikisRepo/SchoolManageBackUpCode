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

		// GET: api/<StaffFeedbackController>
		[HttpGet("GeteLetterByAccount/{accountId}")]
		public IActionResult GeteLetterByAccount(int accountId)
		{

			var _staffMobileNumber = Convert.ToInt64(_dbcontext.Accounts.Where(account => account.Id == accountId).FirstOrDefault().Email);

			return Ok((from staff in _dbcontext.Staffs
					   join staffeLetters in _dbcontext.StaffeLetters on staff.EmployeeId equals staffeLetters.Empid
					   select new
					   {
						   staffeLetterId = staffeLetters.StaffeLetterId,
						   letterType = staffeLetters.LetterType,
						   department = staffeLetters.Department,
						   TeacherId = staffeLetters.TeacherId,
						   month = staffeLetters.Month,
						   year = staffeLetters.Year,
						   staffName = staff.FirstName,
						   Empid = staffeLetters.Empid,
						   mobile = staff.Mobile
					   }).Where(x => x.mobile == _staffMobileNumber).ToList());
		}
		// GET: api/<StaffeLetterController>
		[HttpGet]
		public IEnumerable<StaffeLetter> Get()
		{
			return _dbcontext.StaffeLetters.ToList();
		}

		// GET api/<StaffeLetterController>/5
		[HttpGet("{id}")]
		public StaffeLetter Get(int id)
		{
			return _dbcontext.StaffeLetters.Where(X => X.StaffeLetterId == id).FirstOrDefault();
		}

		[HttpPost]
		[Route("UploadStaffeLetterAndDocument")]
		public async Task<IActionResult> UploadStaffeLetterAndDocument(IFormFile file, [FromForm] StaffeLetter staffeLetterback)
		{
			if (file != null)
			{
				var staffAttachments = new StaffAttachments();
				staffAttachments.EmployeeId = staffeLetterback.Empid;
				staffAttachments.DocumentType = "Staff eLetter";
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
		[HttpPut("UpdateStaffeLetterAndDocument")]
		public async Task<IActionResult> UpdateStaffeLetterAndDocument(IFormFile file, [FromForm] StaffeLetter staffeLetter)
		{
			var _staffeLetter = _dbcontext.StaffeLetters.Where(X => X.StaffeLetterId == staffeLetter.StaffeLetterId).FirstOrDefault();
			if (file != null)
			{
				var staffAttachments = new StaffAttachments();
				staffAttachments.EmployeeId = staffeLetter.Empid;
				staffAttachments.DocumentType = "Staff eLetter";
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
					staffeLetter.AttachmentId = staffAttachments.StaffAttachmentsId;
					_staffeLetter.AttachmentId = staffeLetter.AttachmentId;

				}
			}

			_staffeLetter.Empid = staffeLetter.Empid;
			_staffeLetter.StaffName = staffeLetter.StaffName;
			_staffeLetter.Department = staffeLetter.Department;
			_staffeLetter.TeacherId = staffeLetter.TeacherId;
			_staffeLetter.LetterType = staffeLetter.LetterType;
			_staffeLetter.Month = staffeLetter.Month;
			_staffeLetter.Year = staffeLetter.Year;

			await _dbcontext.SaveChangesAsync();
			return Ok();
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
