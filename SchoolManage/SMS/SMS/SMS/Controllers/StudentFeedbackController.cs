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
	public class StudentFeedbackController : ControllerBase
	{
    private IWebHostEnvironment _hostingEnvironment;
    private readonly MysqlDataContext _dbcontext;
		public StudentFeedbackController(IWebHostEnvironment environment, MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
      _hostingEnvironment = environment;
    }
		// GET: api/<StudentFeedbackController>
		[HttpGet]
		public IActionResult Get()
		{
      return Ok((from studfeedback in _dbcontext.StudentFeedbacks
                join staff in _dbcontext.Staffs on studfeedback.StaffId equals staff.StaffId
                select new
                {
                  studentFeedbackId = studfeedback.StudentFeedbackId,
                  feedbackType = studfeedback.FeedbackType,
                  date = studfeedback.Date,
                  Class = studfeedback.Class,
                  Feedbacktitle = studfeedback.Feedbacktitle,
                  section = studfeedback.Section,
                  description = studfeedback.Description,
                  attachmentId = studfeedback.AttachmentId,
                  admissionNumber = studfeedback.AdmissionNumber,
                  dateCreated = studfeedback.DateCreated,
                  staffName = staff.FirstName
                }).ToList());
      //return _dbcontext.StudentFeedbacks.Join(_dbcontext.Staffs, a => a.StaffId, b => b.StaffId, (a, b) => a.StaffId).ToList().Select(x => {
      //  x.
      //})
    }

		// GET api/<StudentFeedbackController>/5
		[HttpGet("{id}")]
		public StudentFeedback Get(int id)
		{
			return _dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault();
		}

		// POST api/<StudentFeedbackController>
		[HttpPost]
		public void Post([FromBody] StudentFeedback studentFeedbackReq)
		{
      studentFeedbackReq.DateCreated = DateTime.Now;
      _dbcontext.StudentFeedbacks.Add(studentFeedbackReq);
			_dbcontext.SaveChanges();
		}

    [HttpPost]
    [Route("UploadStudentFeedbackAndDocument")]
    public async Task<IActionResult> UploadStudentFeedbackAndDocument(IFormFile file, [FromForm] StudentFeedback studentFeedbackReq)
    {
      var studentAttachments = new StudentAttachments();
      studentAttachments.AdmissionNumber = studentFeedbackReq.AdmissionNumber;
      studentAttachments.DocumentType = "Student Feedback";
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

        _dbcontext.StudentDocuments.Add(studentAttachments);
        _dbcontext.SaveChanges();

        studentFeedbackReq.DateCreated = DateTime.Now;
        studentFeedbackReq.AttachmentId = studentAttachments.StudentAttachmentsId;
        await _dbcontext.StudentFeedbacks.AddAsync(studentFeedbackReq);
        await _dbcontext.SaveChangesAsync();

      }
      return Ok();
    }

    // PUT api/<StudentFeedbackController>/5
    [HttpPut("{id}")]
		public void Put(int id, [FromBody] StudentFeedback studentFeedbackReq)
		{
			_dbcontext.Entry(_dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault()).CurrentValues.SetValues(studentFeedbackReq);
			_dbcontext.SaveChanges();
		}

		// DELETE api/<StudentFeedbackController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		//	if (_dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault() != null)
		//	{
				_dbcontext.Remove(_dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault());
				_dbcontext.SaveChanges();
			//}
		}
	}
}
