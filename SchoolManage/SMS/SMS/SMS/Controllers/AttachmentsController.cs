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
	public class AttachmentsController : ControllerBase
	{
		private readonly SchoolManagementContext _context;
		public AttachmentsController(SchoolManagementContext dbcontext)
		{
			this._context = dbcontext;
		}
		// GET: api/<AttachmentsController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<AttachmentsController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_context.MyAttachments.Select(X=>X.Id == id).FirstOrDefault());
		}

		// POST api/<AttachmentsController>
		[HttpPost]
		public void Post([FromBody] Attachments _Attachments)
		{
			this._context.MyAttachments.Add(_Attachments);
			this._context.SaveChanges();
		}

		// PUT api/<AttachmentsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<AttachmentsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
