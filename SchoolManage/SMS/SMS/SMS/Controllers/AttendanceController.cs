using Microsoft.AspNetCore.Mvc;
using SMS.Models.Attendance;
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
	public class AttendanceController : ControllerBase
	{
		//private readonly SchoolManagementContext _dbcontext;
		private readonly MysqlDataContext _dbcontext;
		public AttendanceController(MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}

		// GET: api/<AttendanceController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<AttendanceController>/5
		[HttpPost("SearchStaffbyDepartmentAndStaffType")]
		public async Task<IEnumerable<StaffAttendance>> Post(StaffAttendanceSearchRequest request)
		{
			var todaysStaff = _dbcontext.Staffs.Where(x => x.DepartmentId == request.department && x.StaffTypeId == request.staffType).ToList();
			StaffAttendance[] _staffattendance = new StaffAttendance[todaysStaff.Count];
			int i = 0;
			foreach (var staff in todaysStaff)
			{
				_staffattendance[i] = new StaffAttendance()
				{
					StaffName = staff.FirstName,
					EmployeeId = staff.EmployeeId,
					Absent = 0,
					HalfDay = 0,
					Present = 1,
					AttendanceDate = request.DateFor
				};
				i++;
			}
			await _dbcontext.StaffAttendances.AddRangeAsync(_staffattendance);
			await _dbcontext.SaveChangesAsync();
			return _dbcontext.StaffAttendances.Where(x => x.AttendanceDate == request.DateFor).ToList();
		}

		// POST api/<AttendanceController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<AttendanceController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<AttendanceController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
