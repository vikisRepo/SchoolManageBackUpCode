using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffFeedbackController : ControllerBase
	{

		private readonly SchoolManagementContext _dbcontext;
		public StaffFeedbackController(SchoolManagementContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}
		// GET: api/<StaffFeedbackController>
		[HttpGet]
		public IEnumerable<StaffFeedback> Get()
		{
			return _dbcontext.StaffFeedbacks.ToList();
		}

		// GET api/<StaffFeedbackController>/5
		[HttpGet("{id}")]
		public StaffFeedback Get(string id)
		{
			return _dbcontext.StaffFeedbacks.Where(X => X.Empid == id).FirstOrDefault();
		}

		// POST api/<StaffFeedbackController>
		[HttpPost]
		public void Post([FromBody] StaffFeedback staffFeedback)
		{
			_dbcontext.StaffFeedbacks.Add(staffFeedback);
			_dbcontext.SaveChanges();
		}

		// PUT api/<StaffFeedbackController>/5
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] StaffFeedback staffFeedback)
		{
			_dbcontext.Entry(_dbcontext.StaffFeedbacks.Where(X => X.Empid == id).FirstOrDefault()).CurrentValues.SetValues(staffFeedback);
			_dbcontext.SaveChanges();
		}

		// DELETE api/<StaffFeedbackController>/5
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_dbcontext.Remove(_dbcontext.StaffFeedbacks.Where(X => X.Empid == id).FirstOrDefault());
			_dbcontext.SaveChanges();
		}
	}
}
