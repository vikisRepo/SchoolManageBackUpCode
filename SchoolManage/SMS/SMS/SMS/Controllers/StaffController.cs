using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models.Accounts;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
//	[Authorize]
	//[AllowAnonymous]
	public class StaffController : ControllerBase
	{
		private readonly MysqlDataContext _dbcontext;

		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;

		public StaffController(MysqlDataContext dbcontext,
			IAccountService accountService,
			IMapper mapper)
		{
			this._dbcontext = dbcontext;
			_accountService = accountService;
			_mapper = mapper;
		}

		// GET: api/<StaffController>
		[HttpGet]
		public IEnumerable<Staff> Get()
		{
			return _dbcontext.Staffs.Include(X => X.Addresses).Include(g => g.experiences).ToList();
		}

		// GET api/<StaffController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			return Ok(_dbcontext.Staffs.Where(X => X.Mobile == id).Include(X => X.Addresses).Include(g => g.experiences).FirstOrDefault());
		}

		// POST api/<StaffController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Staff staff)
		{

			RegisterRequest model = new RegisterRequest();
			model.Title = staff.SalutationId;
			model.FirstName = staff.FirstName;
			model.Email = Convert.ToString(staff.Mobile);
			model.LastName = staff.LastName;
			model.AcceptTerms = true;
			model.Password = staff.FirstName + Convert.ToString(staff.Mobile);
			model.ConfirmPassword = staff.FirstName + Convert.ToString(staff.Mobile);
			_accountService.Register(model, Request.Headers["origin"], true);
			var account = _dbcontext.Accounts.SingleOrDefault(x => x.Email == model.Email);

			staff.StaffId = account.Id;

			_dbcontext.Staffs.Add(staff);
			_dbcontext.SaveChanges();

			return StatusCode(StatusCodes.Status200OK, new { Status = "Success", Message = "User added successfully!" });
		}

		// PUT api/<StaffController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(long id, [FromBody] Staff staff)
		{

            try
            {
                var updateStaff = _dbcontext.Staffs.Where(X => X.Mobile == id).FirstOrDefault();
				//excluding Address, ecxperience, staffid 
                updateStaff.AadharNumber = staff.AadharNumber;
                updateStaff.ActiveId = staff.ActiveId;
				updateStaff.BankAccountNumber = staff.BankAccountNumber;
				updateStaff.BankBranch = staff.BankBranch;
				updateStaff.BankIfscCode = staff.BankIfscCode;
				updateStaff.BankName = staff.BankName;
				updateStaff.BloodGroup = staff.BloodGroup;
				updateStaff.DepartmentId = staff.DepartmentId;
				updateStaff.DesignationId = staff.DesignationId;
				updateStaff.Dob = staff.Dob;
				updateStaff.EducationId = staff.EducationId;
				updateStaff.EmailId = staff.EmailId;
				updateStaff.EmployeeId = staff.EmployeeId;
				updateStaff.EmployeementStatusId = staff.EmployeementStatusId;
				updateStaff.Epfnumber = staff.Epfnumber;
				updateStaff.Esinumber = staff.Esinumber;
				updateStaff.FatherMobileNumber = staff.FatherMobileNumber;
				updateStaff.FatherName = staff.FatherName;
				updateStaff.FatherOccupation = staff.FatherOccupation;
				updateStaff.FirstName = staff.FirstName;
				updateStaff.Gender = staff.Gender;
				updateStaff.JoiningDate = staff.JoiningDate;
				updateStaff.LanguagesId = staff.LanguagesId;
				updateStaff.LastName = staff.LastName;
				updateStaff.Marritalsatus = staff.Marritalsatus;
				updateStaff.MiddleName = staff.MiddleName;
				updateStaff.Mobile = staff.Mobile;
				updateStaff.MotherMobileNumber = staff.MotherMobileNumber;
				updateStaff.MotherName = staff.MotherName;
				updateStaff.MotherOccupation = staff.MotherOccupation;
				updateStaff.MotherTongue = staff.MotherTongue;
				updateStaff.NationalityId = staff.NationalityId;
				updateStaff.OfficialEmailId = staff.OfficialEmailId;
				updateStaff.PanNumber = staff.PanNumber;
				updateStaff.ReligionId = staff.ReligionId;
				updateStaff.ReportingTo = staff.ReportingTo;
				updateStaff.RoleId = staff.RoleId;
				updateStaff.SalutationId = staff.SalutationId;
				updateStaff.SpouseMobileNumber = staff.SpouseMobileNumber;
				updateStaff.SpouseName = staff.SpouseName;
				updateStaff.SpouseOccupation = staff.SpouseOccupation;
				updateStaff.StaffAddressId = staff.StaffAddressId;
				updateStaff.StaffExperienceId = staff.StaffExperienceId;
				updateStaff.StaffTypeId = staff.StaffTypeId;
				updateStaff.TeacherId = staff.TeacherId;
				updateStaff.Uannumber = staff.Uannumber;
				updateStaff.WeddingDate = staff.WeddingDate;
                await _dbcontext.SaveChangesAsync();

				return Ok(staff);
            }
            catch (Exception Ex)
            {
				return BadRequest(Ex);
            }
        }

		// DELETE api/<StaffController>/5
		[HttpDelete("{id}")]
		public async Task Delete(long id)
		{
			_dbcontext.Remove(_dbcontext.Staffs.Where(X => X.Mobile == id).FirstOrDefault());
			await _dbcontext.SaveChangesAsync();
		}

		[HttpPost("PostStaffFeedback")]
		public async Task<IActionResult> PostStaffFeedback([FromBody] StaffFeedback staffFeedback)
		{
			//_dbcontext.StaffFeedbacks.Add(staffFeedback);
			//await _dbcontext.SaveChangesAsync();

			return Ok();
		}
	}
}
