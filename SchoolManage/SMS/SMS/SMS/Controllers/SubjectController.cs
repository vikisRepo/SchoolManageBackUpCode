using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Models.Setup;
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
	public class SubjectController : ControllerBase
	{
		//private readonly SchoolManagementContext _dbcontext;
		private readonly MysqlDataContext _dbcontext;
		public SubjectController(MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}

		// GET: api/<SubjectController>
		[HttpGet]
		public IEnumerable<Subject> Get()
		{
			return _dbcontext.Subjects.ToList();
		}

		// GET api/<SubjectController>/5
		[HttpGet("{id}")]
		public Subject Get(int id)
		{
			return _dbcontext.Subjects.Where(X => X.SubjectID == id).FirstOrDefault();
		}

		// POST api/<SubjectController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Subject subject)
		{

			_dbcontext.Subjects.Add(subject);	
			await _dbcontext.SaveChangesAsync();

			return Ok();
		}

		// PUT api/<SubjectController>/5
		[HttpPut("{id}")]
		public async Task Put(int id, [FromBody] Subject subject)
		{
			var _Current = _dbcontext.Subjects.Where(X => X.SubjectID == id).FirstOrDefault();

			if (_Current != null)
			{
				_Current.SubjectDescr = subject.SubjectDescr;
			}
			
			await _dbcontext.SaveChangesAsync();
		}

		// DELETE api/<SubjectController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			_dbcontext.Remove(_dbcontext.Subjects.Where(X => X.SubjectID == id).FirstOrDefault());
			await _dbcontext.SaveChangesAsync();
		}
	}
}
