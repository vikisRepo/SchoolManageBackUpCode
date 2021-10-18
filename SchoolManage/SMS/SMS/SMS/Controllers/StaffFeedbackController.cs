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
	public class StaffFeedbackController : ControllerBase
	{
    private IWebHostEnvironment _hostingEnvironment;
    private readonly MysqlDataContext _dbcontext;
		public StaffFeedbackController(IWebHostEnvironment environment, MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
      _hostingEnvironment = environment;

    }
    // GET: api/<StaffFeedbackController>
    [HttpGet("GetFeedbackByAccount/{accountId}")]
    public IActionResult GetFeedbackByAccount(int accountId)
		{

      var _staffMobileNumber = Convert.ToInt64(_dbcontext.Accounts.Where(account => account.Id == accountId).FirstOrDefault().Email);

      return Ok((from staff in _dbcontext.Staffs 
                 join stafffeedback in _dbcontext.StaffFeedbacks on staff.EmployeeId equals stafffeedback.Empid
                 select new
                 {
                   staffFeedbackId = stafffeedback.StaffFeedbackID,
                   feedbackType = stafffeedback.FeedbackType,
                   date = stafffeedback.Date,
                   Feedbacktitle = stafffeedback.Feedbacktitle,
                   description = stafffeedback.Description,
                   attachmentId = stafffeedback.AttachmentId,
                   dateCreated = stafffeedback.DateCreated,
                   staffName = staff.FirstName,
                   Empid = stafffeedback.Empid,
                   mobile = staff.Mobile
                 }).Where(x => x.mobile == _staffMobileNumber).ToList());
    }

    // GET api/<StaffFeedbackController>/5
    [HttpGet]
    public IEnumerable<StaffFeedback> Get()
    {
      return _dbcontext.StaffFeedbacks.ToList();
    }

    // GET api/<StaffFeedbackController>/5
    [HttpGet("{id}")]
		public StaffFeedback Get(int id)
		{
			return _dbcontext.StaffFeedbacks.Where(X => X.StaffFeedbackID == id).FirstOrDefault();
		}

    [HttpPost]
    [Route("UploadStaffFeedbackAndDocument")]
    public async Task<IActionResult> UploadStaffFeedbackAndDocument(IFormFile file, [FromForm] StaffFeedback staffFeedback)
    {
      if (file != null)
      {
        var staffAttachments = new StaffAttachments();
        staffAttachments.EmployeeId = staffFeedback.Empid;
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

          staffFeedback.DateCreated = DateTime.Now;
          staffFeedback.AttachmentId = staffAttachments.StaffAttachmentsId;


        }
      }
      await _dbcontext.StaffFeedbacks.AddAsync(staffFeedback);
      await _dbcontext.SaveChangesAsync();
      return Ok();
    }

    // PUT api/<StaffFeedbackController>/5
    [HttpPut("UpdateStaffFeedbackAndDocument")]
    public async Task<IActionResult> UpdateStaffFeedbackAndDocument(IFormFile file, [FromForm] StaffFeedback staffFeedback)
    {
      var _staffFeedback = _dbcontext.StaffFeedbacks.Where(X => X.StaffFeedbackID == staffFeedback.StaffFeedbackID).FirstOrDefault();
      if (file != null)
      {
        var staffAttachments = new StaffAttachments();
        staffAttachments.EmployeeId = staffFeedback.Empid;
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

          staffFeedback.DateCreated = DateTime.Now;
          staffFeedback.AttachmentId = staffAttachments.StaffAttachmentsId;
          _staffFeedback.AttachmentId = staffFeedback.AttachmentId;

        }
      }

      _staffFeedback.Empid = staffFeedback.Empid;
      _staffFeedback.StaffName = staffFeedback.StaffName;
      _staffFeedback.Department = staffFeedback.Department;
      _staffFeedback.TeacherId = staffFeedback.TeacherId;
      _staffFeedback.FeedbackType = staffFeedback.FeedbackType;
      _staffFeedback.Feedbacktitle = staffFeedback.Feedbacktitle;
      _staffFeedback.Description = staffFeedback.Description;
      _staffFeedback.Date = staffFeedback.Date;
      _staffFeedback.DateCreated = DateTime.Now;

      await _dbcontext.SaveChangesAsync();
      return Ok();
    }

    // DELETE api/<StaffFeedbackController>/5
    [HttpDelete("{id}")]
		public void Delete(string id)
		{
			_dbcontext.Remove(_dbcontext.StaffFeedbacks.Where(X => X.Empid == id).FirstOrDefault());
			_dbcontext.SaveChanges();
		}
	}
}
