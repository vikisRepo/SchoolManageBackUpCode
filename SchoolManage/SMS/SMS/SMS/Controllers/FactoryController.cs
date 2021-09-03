using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class FactoryController : ControllerBase
	{
		private readonly MysqlDataContext _dbcontext;

		public FactoryController(MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}

		#region Religion
		// GET: api/<FactoryController>
		[HttpGet("Religions")]
		public IEnumerable<Religion> Religions()
		{
			return _dbcontext.Religions.ToList();
		}
		#endregion

		#region Nationality

		[HttpGet("Nationalities")]
		public IEnumerable<Nationality> Nationalities()
		{
			return _dbcontext.Nationalities.ToList();
		}
		#endregion

		#region Department

		[HttpGet("Departments")]
        public IEnumerable<Department> Departments()
        {
            return _dbcontext.Departments.ToList();
        }
        #endregion

        #region Designation

        [HttpGet("Designations")]
        public IEnumerable<Designation> Designations()
        {
            return _dbcontext.Designations.ToList();
        }
        #endregion

        #region  EmployeeStatus

        //[HttpGet("EmployeeStatus")]
        //public IEnumerable<EmployeementStatus> EmployeeStatus()
        //{
        //	return _dbcontext.EmployeementStatuses.ToList();
        //}
        #endregion

        #region  Language

        [HttpGet("Language")]
		public IEnumerable<Language> Language()
		{
			return _dbcontext.Languages.ToList();
		}
        #endregion

        #region StaffType
		
		[HttpGet("StaffType")]
		public IEnumerable<StaffType> StaffTypes()
        {
			return _dbcontext.StaffTypes.ToList();
        }

        #endregion

        #region  city

        [HttpGet("City")]
		public IEnumerable<City> City()
		{
			return _dbcontext.Cities.ToList();
		}
		#endregion

		#region  state

		[HttpGet("State")]
		public IEnumerable<State> State()
		{
			return _dbcontext.States.ToList();
		}
		#endregion

		#region  Country

		[HttpGet("Country")]
		public IEnumerable<Country> country()
		{
			return _dbcontext.Countries.ToList();
		}
        #endregion

        #region education
		[HttpGet("education")]
		public IEnumerable<Education> Educations()
        {
			return _dbcontext.Educations.ToList();
        }
		#endregion

		#region RepotingTo
		[HttpGet("RepotingTo")]
		public IEnumerable<ReportingTo> ReportingTos()
        {
			return _dbcontext.ReportingTos.ToList();
        }
		#endregion

		#region schoolName
		[HttpGet("schoolName")]
		public IEnumerable<SchoolName> schoolNames()
        {
			return _dbcontext.SchoolNames.ToList();
        }
		#endregion

		#region bank
		[HttpGet("Bank")]
		public IEnumerable<Bank> banks()
        {
			return _dbcontext.Banks.ToList();
        }
        #endregion
    }
}
