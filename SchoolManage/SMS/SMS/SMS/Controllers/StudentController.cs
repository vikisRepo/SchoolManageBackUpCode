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
		private readonly MysqlDataContext _dbcontext;

		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;

		public StudentController(MysqlDataContext dbcontext,
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
			return _dbcontext.Students.Include(d => d.Dependentsdetails).ToList();
		}

		// GET api/<StudentController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_dbcontext.Students.Where(X => X.StudentId == id).Include(d => d.Dependentsdetails).FirstOrDefault());
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
			var updatestudent = _dbcontext.Students.Where(X => X.StudentId == id).FirstOrDefault();

            updatestudent.Salutation = student.Salutation;
            updatestudent.FirstName = student.FirstName;
            updatestudent.MiddleName = student.MiddleName;
            updatestudent.LastName = student.LastName;
            updatestudent.Dob = student.Dob;
            updatestudent.BloodGroup = student.BloodGroup;
            updatestudent.NationalityId = student.NationalityId;
            updatestudent.ReligionId = student.ReligionId;
            updatestudent.Gender = student.Gender;
            updatestudent.EmailId = student.EmailId;
            updatestudent.AadharNumber = student.AadharNumber;
            updatestudent.AdmissionDate = student.AdmissionDate;
            updatestudent.Class = student.Class;
            updatestudent.Section = student.Section;
            updatestudent.RollNo = student.RollNo;
            updatestudent.FirstLanguage = student.FirstLanguage;
            updatestudent.SecondLanguage = student.SecondLanguage;
            updatestudent.EmisNumber = student.EmisNumber;
            updatestudent.schoolName = student.schoolName;
            updatestudent.schoolBrand = student.schoolBrand;
            updatestudent.passingOutSchool = student.passingOutSchool;
            updatestudent.yearofattendence = student.yearofattendence;
            updatestudent.AcademicPrecentage = student.AcademicPrecentage;
            updatestudent.ReasonForLeaving = student.ReasonForLeaving;
            updatestudent.CurrentLine1 = student.CurrentLine1;
            updatestudent.CurrentLine2 = student.CurrentLine2;
            updatestudent.CurrentLine3 = student.CurrentLine3;
            updatestudent.CurrentCity = student.CurrentCity;
            updatestudent.CurrentSate = student.CurrentSate;
            updatestudent.CurrentCountry = student.CurrentCountry;
            updatestudent.CurrentPincode = student.CurrentPincode;
            updatestudent.PermenantLine1 = student.PermenantLine1;
            updatestudent.PermenantLine2 = student.PermenantLine2;
            updatestudent.PermenantLine3 = student.PermenantLine3;
            updatestudent.PermenantCity = student.PermenantCity;
            updatestudent.PermenantSate = student.PermenantSate;
            updatestudent.PermenantCountry = student.PermenantCountry;
            updatestudent.PermenantPincode = student.PermenantPincode;
            //updatestudent.FatherFirstName = student.FatherFirstName;
            //updatestudent.FatherLastName = student.FatherLastName;
            //updatestudent.FatherMiddleName = student.FatherMiddleName;
            //updatestudent.FatherMobileNumber = student.FatherMobileNumber;
            //updatestudent.FatherOccupation = student.FatherOccupation;
            //updatestudent.FatherSalutationId = student.FatherSalutationId;
            //updatestudent.FatherAadharNumber = student.FatherAadharNumber;
            //updatestudent.FatherAnnualIncome = student.FatherAnnualIncome;
            //updatestudent.FatherBvEmployee = student.FatherBvEmployee;
            //updatestudent.FatherCompany = student.FatherCompany;
            //updatestudent.FatherDesignation = student.FatherDesignation;
            //updatestudent.FatherEmail = student.FatherEmail;
            //updatestudent.MotherFirstName = student.MotherFirstName;
            //updatestudent.MotherLastName = student.MotherLastName;
            //updatestudent.MotherMiddleName = student.MotherMiddleName;
            //updatestudent.MotherMobileNumber = student.MotherMobileNumber;
            //updatestudent.MotherOccupation = student.MotherOccupation;
            //updatestudent.MotherSalutationId = student.MotherSalutationId;
            //updatestudent.MotherAadharNumber = student.MotherAadharNumber;
            //updatestudent.MotherAnnualIncome = student.MotherAnnualIncome;
            //updatestudent.MotherBvEmployee = student.MotherBvEmployee;
            //updatestudent.MotherCompany = student.MotherCompany;
            //updatestudent.MotherDesignation = student.MotherDesignation;
            //updatestudent.MotherEmail = student.MotherEmail;
            //updatestudent.LegalFirstName = student.LegalFirstName;
            //updatestudent.LegalLastName = student.LegalLastName;
            //updatestudent.LegalMiddleName = student.LegalMiddleName;
            //updatestudent.LegalMobileNumber = student.LegalMobileNumber;
            //updatestudent.LegalOccupation = student.LegalOccupation;
            //updatestudent.LegalSalutationId = student.LegalSalutationId;
            //updatestudent.LegalAadharNumber = student.LegalAadharNumber;
            //updatestudent.LegalAnnualIncome = student.LegalAnnualIncome;
            //updatestudent.LegalBvEmployee = student.LegalBvEmployee;
            //updatestudent.LegalCompany = student.LegalCompany;
            //updatestudent.LegalDesignation = student.LegalDesignation;
            //updatestudent.LegalEmail = student.LegalEmail;
            //updatestudent.LocalGuardianFirstName = student.LocalGuardianFirstName;
            //updatestudent.LocalGuardianLastName = student.LocalGuardianLastName;
            //updatestudent.LocalGuardianMiddleName = student.LocalGuardianMiddleName;
            //updatestudent.LocalGuardianMobileNumber = student.LocalGuardianMobileNumber;
            //updatestudent.LocalGuardianOccupation = student.LocalGuardianOccupation;
            //updatestudent.LocalGuardianSalutationId = student.LocalGuardianSalutationId;
            //updatestudent.LocalGuardianAadharNumber = student.LocalGuardianAadharNumber;
            //updatestudent.LocalGuardianAnnualIncome = student.LocalGuardianAnnualIncome;
            //updatestudent.LocalGuardianBvEmployee = student.LocalGuardianBvEmployee;
            //updatestudent.LocalGuardianCompany = student.LocalGuardianCompany;
            //updatestudent.LocalGuardianDesignation = student.LocalGuardianDesignation;
            //updatestudent.LocalGuardianEmail = student.LocalGuardianEmail;
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
