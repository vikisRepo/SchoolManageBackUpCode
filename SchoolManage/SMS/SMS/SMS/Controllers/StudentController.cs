using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
	[AllowAnonymous]
	//[Authorize]
	public class StudentController : ControllerBase
	{
		private readonly DataContext _dbcontext;

		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;

		public StudentController(DataContext dbcontext,
			IAccountService accountService,
			IMapper mapper)
		{
			this._dbcontext = dbcontext;
			_accountService = accountService;
			_mapper = mapper;
		}
		// GET: api/<StudentController>
		[HttpGet]
		public IEnumerable<Student> Get()
		{
			return _dbcontext.Students.ToList();
		}

		// GET api/<StudentController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_dbcontext.Students.Where(X => X.StudentId == id).FirstOrDefault());
		}

		// POST api/<StudentController>
		[HttpPost]
		[AllowAnonymous]
		public void Post([FromBody] Student student)
		{
			RegisterRequest model = new RegisterRequest();
			model.Title = student.Salutation;
			model.FirstName = student.FirstName;
			model.Email = Convert.ToString(student.AdmissionNumber);
			model.LastName = student.LastName;
			model.AcceptTerms = true;
			model.Password = student.FirstName + Convert.ToString(student.AdmissionNumber);
			model.ConfirmPassword = student.FirstName + Convert.ToString(student.AdmissionNumber);
			_accountService.Register(model, Request.Headers["origin"]);
			var account = _dbcontext.Accounts.SingleOrDefault(x => x.Email == model.Email);
			student.StudentId =  account.Id;
			_dbcontext.Students.Add(student);
			_dbcontext.SaveChanges();
		}

		// PUT api/<StudentController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Student student)
		{
			_dbcontext.Entry(_dbcontext.Students.Where(X => X.StudentId == id).FirstOrDefault()).CurrentValues.SetValues(student);
			_dbcontext.SaveChanges();
		}

		// DELETE api/<StudentController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_dbcontext.Remove(_dbcontext.Students.Where(X => X.StudentId == id).FirstOrDefault());
			_dbcontext.SaveChanges();
		}
	}
}
