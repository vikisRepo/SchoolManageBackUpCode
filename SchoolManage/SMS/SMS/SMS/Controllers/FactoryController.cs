using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Models.Inventory;
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

        [HttpGet("EmployeeStatus")]
        public IEnumerable<EmployeementStatus> EmployeeStatus()
        {
            return _dbcontext.EmployeementStatuses.ToList();
        }
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

		#region bloodgroup
		[HttpGet("Bloodgroup")]
		public IEnumerable<Bloodgroup> bloodgroup()
		{
			return _dbcontext.Bloodgroups.ToList();
		}
		#endregion

		#region maritalstatus
		[HttpGet("MaritalStatus")]
		public IEnumerable<MaritalStatus> maritalStatus()
		{
			return _dbcontext.Maritalstatus.ToList();
		}
		#endregion

		#region gender
		[HttpGet("Gender")]
		public IEnumerable<Gender> gender()
		{
			return _dbcontext.Genders.ToList();
		}
		#endregion

		#region salutation

		[HttpGet("Salutation")]
		public IEnumerable<Salutation> Salutationes()
		{
			return _dbcontext.Salutations.ToList();
		}
		#endregion

		#region Role
		[HttpGet("Roles")]
        public IEnumerable<Role> Roles()
        {
            return _dbcontext.Roles.ToList();
        }
		#endregion

		#region InventoryItemType
		[HttpGet("InventoryItemTypes")]
		public IEnumerable<InventoryItemType> InventoryItemTypes()
		{
			return _dbcontext.InventoryItemTypes.ToList();
		}
		#endregion

		#region InventoryItemUsageArea
		[HttpGet("InventoryItemUsageAreas")]
		public IEnumerable<InventoryItemUsageArea> InventoryItemUsageAreas()
		{
			return _dbcontext.InventoryItemUsageAreas.ToList();
		}
		#endregion

		#region AdmissionNobyClassandSection
		[HttpGet("AdmissionNobyClassandSection/{className}/{Section}")]
		public IActionResult AdmissionNobyClassandSection(string className,string Section)
		{
			return  Ok( _dbcontext.Students.Where(x  => x.Class ==className && x.Section == Section).Select(y => new { y.StudentId, y.AdmissionNumber}).ToList());
		}
		#endregion

		#region StaffNames
		[HttpGet("StaffNames")]
		public IActionResult StaffNames()
		{
			return Ok(_dbcontext.Staffs.Select(x => new {
				StaffName = string.Format("{0} {1}", x.FirstName, x.LastName),
				x.StaffId
			  }).ToList());
		}
    #endregion

    #region GetEmployeeDetails
    [HttpGet("GetEmployeeDetails")]
    public IActionResult GetEmployeeDetails()
    {
      return Ok(_dbcontext.Staffs.Select(x => new
      {
        x.EmployeeId,
        DepartmentName = _dbcontext.Departments.Where(X => X.DepartmentId == x.DepartmentId).FirstOrDefault().DepartmentName,
        x.TeacherId,
        StaffName = string.Format("{0} {1}", x.FirstName, x.LastName)
      }).ToList());
    }
    #endregion
  }
}
