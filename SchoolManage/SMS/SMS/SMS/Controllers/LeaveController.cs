using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMS.Models.Leave;
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
	public class LeaveController : ControllerBase
	{
		private readonly MysqlDataContext _dbcontext;
		private readonly IMapper _mapper;
		public LeaveController(MysqlDataContext dbcontext, IMapper mapper)
		{
			this._dbcontext = dbcontext;
			this._mapper = mapper;
		}
		// GET: api/<LeaveController>
		[HttpGet("StudentLeave")]
		public IEnumerable<StudentLeave> StudentLeave()
		{
			return this._dbcontext.StudentLeaves.ToList();
		}

		// GET: api/<LeaveController>
		[HttpGet("StaffLeave")]
		public IEnumerable<StaffLeave> StaffLeave()
		{
			return this._dbcontext.StaffLeaves.ToList();
		}

		// GET api/<LeaveController>/5
		[HttpGet("StudentLeave/{id}")]
		public List<StudentLeave> StudentLeave(int id)
		{
			return _dbcontext.StudentLeaves.Where(X => X.StudentLeaveId == id).ToList();
		}

		// GET api/<LeaveController>/5
		[HttpGet("StaffLeave/{id}")]
		public List<StaffLeave> StaffLeave(int id)
		{
			return _dbcontext.StaffLeaves.Where(X => X.StaffLeaveId == id).ToList();
		}

		// POST api/<LeaveController>
		[HttpPost("CreateStudentLeave")]
		public void CreateStudentLeave([FromBody] StudentLeaveReq request)
		{
			StudentLeave value = _mapper.Map<StudentLeave>(request);
			_dbcontext.StudentLeaves.Add(value);
			_dbcontext.SaveChanges();
		}

		// POST api/<LeaveController>
		[HttpPost("CreateStaffLeave")]
		public void CreateStaffLeave([FromBody] StaffLeaveReq request)
		{
			StaffLeave value = _mapper.Map<StaffLeave>(request);
			_dbcontext.StaffLeaves.Add(value);
			_dbcontext.SaveChanges();
		}

		// PUT api/<LeaveController>/5
		[HttpPut("UpdateStudentLeave/{id}")]
		public void UpdateStudentLeave(int id, [FromBody] StudentLeaveReq request)
		{
			StudentLeave _studentleave = _dbcontext.StudentLeaves.Where(X => X.StudentLeaveId == id).SingleOrDefault();
			var value = _mapper.Map<StudentLeaveReq, StudentLeave>(request, _studentleave);
			_dbcontext.SaveChanges();
		}

		// PUT api/<LeaveController>/5
		[HttpPut("UpdateStaffLeave/{id}")]
		public void UpdateStaffLeave(int id, [FromBody] StaffLeaveReq request)
		{
			StaffLeave _staffleave = _dbcontext.StaffLeaves.Where(X => X.StaffLeaveId == id).SingleOrDefault();
			var value = _mapper.Map<StaffLeaveReq, StaffLeave>(request, _staffleave);
			_dbcontext.SaveChanges();
		}

		// DELETE api/<LeaveController>/5
		[HttpDelete("DeleteStudentLeave/{id}")]
		public void DeleteStudentLeave(int id)
		{
			StudentLeave _studentleave = _dbcontext.StudentLeaves.Where(X => X.StudentLeaveId == id).SingleOrDefault();
			if (_studentleave != null)
			{
				_dbcontext.StudentLeaves.Remove(_studentleave);
				_dbcontext.SaveChanges();
			}
		}


		// DELETE api/<LeaveController>/5
		[HttpDelete("DeleteStaffLeave/{id}")]
		public void DeleteStaffLeave(int id)
		{
			StaffLeave _staffleave = _dbcontext.StaffLeaves.Where(X => X.StaffLeaveId == id).SingleOrDefault();
			if (_staffleave != null)
			{
				_dbcontext.StaffLeaves.Remove(_staffleave);
				_dbcontext.SaveChanges();
			}
		}
	}
}
