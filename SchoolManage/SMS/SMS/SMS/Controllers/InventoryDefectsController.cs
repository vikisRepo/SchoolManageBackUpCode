using Microsoft.AspNetCore.Mvc;
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
	public class InventoryDefectsController : ControllerBase
	{
		private MysqlDataContext _dbContext;

		public InventoryDefectsController(MysqlDataContext dbContext)
		{
			this._dbContext = dbContext;

		}
		// GET: api/<InventoryDefectsController>
		[HttpGet]
		public InventoryDefectRequest Get()
		{
			InventoryDefectRequest inventoryDefectRequestresponse = new InventoryDefectRequest();
			inventoryDefectRequestresponse.InventoryDefects = _dbContext.InventoryDefects.ToArray();
			return inventoryDefectRequestresponse;
		}

		// GET api/<InventoryDefectsController>/5
		[HttpGet("{id}")]
		public InventoryDefectRequest Get(int id)
		{
			InventoryDefectRequest inventoryDefectRequestresponse = new InventoryDefectRequest();
			inventoryDefectRequestresponse.InventoryDefects = _dbContext.InventoryDefects.Where(x => x.InventoryDefectId == id).ToArray();
			return inventoryDefectRequestresponse;
		}

		// POST api/<InventoryDefectsController>
		[HttpPost]
		public void Post([FromBody] InventoryDefectRequest request)
		{
			_dbContext.InventoryDefects.AddRange(request.InventoryDefects);
			_dbContext.SaveChanges();
		}

		// PUT api/<InventoryDefectsController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] InventoryDefect request)
		{
			var updateInventoryDefect = _dbContext.InventoryDefects.Where(X => X.InventoryDefectId == id).FirstOrDefault();
			updateInventoryDefect.ItemCode = request.ItemCode;
			updateInventoryDefect.ItemName = request.ItemName;
			updateInventoryDefect.DefectDesc = request.DefectDesc;
			_dbContext.SaveChanges();
			return Ok();
		}

		// DELETE api/<InventoryDefectsController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var Result = _dbContext.InventoryDefects.Where(X => X.InventoryDefectId == id).SingleOrDefault();
			_dbContext.Remove(Result);
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
