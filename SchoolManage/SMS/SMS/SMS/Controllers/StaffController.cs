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
		private readonly DataContext _dbcontext;

		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;

		public StaffController(DataContext dbcontext,
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
		public async Task Put(long id, [FromBody] Staff staff)
		{
			try
			{
				_dbcontext.Entry(_dbcontext.Staffs.Where(X => X.Mobile == id).FirstOrDefault()).CurrentValues.SetValues(staff);
				await _dbcontext.SaveChangesAsync();
			}
			catch (Exception Ex)
			{ 
				 
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
