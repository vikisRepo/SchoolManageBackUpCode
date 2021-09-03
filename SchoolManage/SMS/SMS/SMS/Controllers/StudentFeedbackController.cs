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
	public class StudentFeedbackController : ControllerBase
	{
		private readonly SchoolManagementContext _dbcontext;
		public StudentFeedbackController(SchoolManagementContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}
		// GET: api/<StudentFeedbackController>
		[HttpGet]
		public IEnumerable<StudentFeedback> Get()
		{
			return _dbcontext.StudentFeedbacks.ToList();
		}

		// GET api/<StudentFeedbackController>/5
		[HttpGet("{id}")]
		public StudentFeedback Get(int id)
		{
			return _dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault();
		}

		// POST api/<StudentFeedbackController>
		[HttpPost]
		public void Post([FromBody] StudentFeedback studentFeedbackReq)
		{
			_dbcontext.StudentFeedbacks.Add(studentFeedbackReq);
			_dbcontext.SaveChanges();
		}

		// PUT api/<StudentFeedbackController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] StudentFeedback studentFeedbackReq)
		{
			_dbcontext.Entry(_dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault()).CurrentValues.SetValues(studentFeedbackReq);
			_dbcontext.SaveChanges();
		}

		// DELETE api/<StudentFeedbackController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		//	if (_dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault() != null)
		//	{
				_dbcontext.Remove(_dbcontext.StudentFeedbacks.Where(X => X.StudentFeedbackId == id).FirstOrDefault());
				_dbcontext.SaveChanges();
			//}
		}
	}
}
