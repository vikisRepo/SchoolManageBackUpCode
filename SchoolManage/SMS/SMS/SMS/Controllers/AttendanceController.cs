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
			var existingStaffAttendance = _dbcontext.StaffAttendances.Where(x => x.AttendanceDate == request.DateFor && x.DepartmentId == request.department && x.StaffTypeId == request.staffType).ToList();

			if (existingStaffAttendance.Count == 0)
			{
				var todaysStaff = _dbcontext.Staffs.Where(x => x.DepartmentId == request.department && x.StaffTypeId == request.staffType).ToList(); //.
				StaffAttendance[] _staffattendance = new StaffAttendance[todaysStaff.Count];
				int i = 0;
				foreach (var staff in todaysStaff)
				{
					_staffattendance[i] = new StaffAttendance()
					{
						StaffName = staff.FirstName,
						EmployeeId = staff.EmployeeId,
						DepartmentId = staff.DepartmentId,
						StaffTypeId = staff.StaffTypeId,
						Absent = 0,
						HalfDay = 0,
						Present = 1,
						AttendanceDate = request.DateFor,
						RowInactive = 0
					};
					i++;
				}
				await _dbcontext.StaffAttendances.AddRangeAsync(_staffattendance);
				await _dbcontext.SaveChangesAsync();
			}

			return _dbcontext.StaffAttendances.Where(x => x.AttendanceDate == request.DateFor && x.DepartmentId == request.department && x.StaffTypeId == request.staffType).ToList();
		}

		// POST api/<AttendanceController>
		[HttpPost("UpdateStaffAttendance")]
		public async Task<bool> UpdateStaffAttendance(StaffAttendanceUpdateRequest request)
		{
			bool Result = false;
			var existingStaffAttendance = _dbcontext.StaffAttendances.Where(x => x.EmployeeId == request.EmployeeId && x.StaffAttendanceId == request.StaffAttendanceId).FirstOrDefault ();

			if (existingStaffAttendance != null)
			{
				switch ((StaffAttendanceTypes)request.UpdateType)
				{
					case (StaffAttendanceTypes.Present):
						{
							existingStaffAttendance.Present = 1;
							existingStaffAttendance.Absent = 0;
							existingStaffAttendance.HalfDay = 0;
							break;
						}
					case StaffAttendanceTypes.Absent:
						{
							existingStaffAttendance.Present = 0;
							existingStaffAttendance.Absent = 1;
							existingStaffAttendance.HalfDay = 0;
							break;
						}
					case StaffAttendanceTypes.HalfDay:
						{
							existingStaffAttendance.Present = 0;
							existingStaffAttendance.Absent = 0;
							existingStaffAttendance.HalfDay = 1;
							break;
						}
					default:
                        {
							break;
                        }

				}

				await _dbcontext.SaveChangesAsync();
				Result = true;

			}

			return Result;

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
