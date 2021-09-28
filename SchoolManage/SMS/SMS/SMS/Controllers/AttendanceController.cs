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
				switch ((AttendanceTypes)request.UpdateType)
				{
					case (AttendanceTypes.Present):
						{
							existingStaffAttendance.Present = 1;
							existingStaffAttendance.Absent = 0;
							existingStaffAttendance.HalfDay = 0;
							break;
						}
					case AttendanceTypes.Absent:
						{
							existingStaffAttendance.Present = 0;
							existingStaffAttendance.Absent = 1;
							existingStaffAttendance.HalfDay = 0;
							break;
						}
					case AttendanceTypes.HalfDay:
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

		[HttpPost("SearchStudentbyClassAndSection")]
		public async Task<IEnumerable<StudentAttendance>> SearchStudentbyClassAndSection(StudentAttendanceSearchRequest request)
		{
			var existingStudentAttendance = _dbcontext.StudentAttendances.Where(x => x.AttendanceDate == request.DateFor && x.Class == request.Class && x.Section == request.Section).ToList(); //

			if (existingStudentAttendance.Count == 0)
			{
				var todaysStudent = _dbcontext.Students.ToList(); //.Where(x => x.Class == request.Class && x.Section == request.Section)
				StudentAttendance[] _studentattendance = new StudentAttendance[todaysStudent.Count];
				int i = 0;
				foreach (var student in todaysStudent)
				{
					_studentattendance[i] = new StudentAttendance()
					{
						StudentName = student.FirstName,
						AdmissionNumber = student.AdmissionNumber,
						Class = student.Class,
						Section = student.Section,
						Absent = 0,
						HalfDay = 0,
						Present = 1,
						AttendanceDate = request.DateFor,
						RowInactive = 0
					};
					i++;
				}
				await _dbcontext.StudentAttendances.AddRangeAsync(_studentattendance);
				await _dbcontext.SaveChangesAsync();
			}

			return _dbcontext.StudentAttendances.ToList(); //.Where(x => x.AttendanceDate == request.DateFor && x.Class == request.Class && x.Section == request.Section)
		}

		// POST api/<AttendanceController>
		[HttpPost("UpdateStudentAttendance")]
		public async Task<bool> UpdateStudentAttendance(StudentAttendanceUpdateRequest request)
		{
			bool Result = false;
			var existingStudentAttendance = _dbcontext.StudentAttendances.Where(x => x.AdmissionNumber == request.AdmissionNumber && x.StudentAttendanceId == request.StudentAttendanceId).FirstOrDefault();

			if (existingStudentAttendance != null)
			{
				switch ((AttendanceTypes)request.UpdateType)
				{
					case (AttendanceTypes.Present):
						{
							existingStudentAttendance.Present = 1;
							existingStudentAttendance.Absent = 0;
							existingStudentAttendance.HalfDay = 0;
							break;
						}
					case AttendanceTypes.Absent:
						{
							existingStudentAttendance.Present = 0;
							existingStudentAttendance.Absent = 1;
							existingStudentAttendance.HalfDay = 0;
							break;
						}
					case AttendanceTypes.HalfDay:
						{
							existingStudentAttendance.Present = 0;
							existingStudentAttendance.Absent = 0;
							existingStudentAttendance.HalfDay = 1;
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
	}
}
