using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
	public class InventoryController : ControllerBase
	{
		private MysqlDataContext _dbContext;

        public InventoryController(MysqlDataContext dbContext)
        {
			this._dbContext = dbContext;

		}

		// GET: api/<InventoryController>
		[HttpGet ("Inventory")]
		public IEnumerable<Inventory> Inventory()
		{
			return this._dbContext.Inventorys.Include(x => x.InventoryItemUsageArea).Include(d => d.InventoryItemType).ToList();
		}

		// GET api/<InventoryController>/5
		[HttpGet("Inventory/{id}")]
		public IActionResult Inventory(int id)
		{
			InventoryReq IR = new InventoryReq();
			Inventory resp = this._dbContext.Inventorys.Where(X => X.InventoryId == id).First();
			if (resp != null)
			{
				IR.itemName = resp.ItemName;
				IR.itemTypeId = resp.InventoryItemTypeId;
				IR.modelNumber = resp.ModelNumber;
				IR.itemUsageId = resp.InventoryItemUsageAreaId;
				IR.serialNumber = resp.SerialNumber;
				IR.warrenOrGarantee = resp.WarrenOrGarantee;
				IR.warrenOrGarenInfo = resp.WarrenOrGarenInfo;
				IR.brandName = resp.Brand;
				IR.quantity = resp.Quantity;
				IR.itemPriceorPerUnit = resp.Price;
				IR.vendorName = resp.VendorName;
				IR.vendorNumber = resp.VendorNumber;
				IR.vendorAddress = resp.VendorAddress;
				return Ok(IR);
			}
			else
				return BadRequest("Not able to find the Inventory");

		}

		// POST api/<InventoryController>
		[HttpPost ("InsertInventory")]
		public void InsertInventory([FromBody] InventoryReq IR)
		{
			var I = new Inventory();

			//I.ItemCode = IR.ItemCode;
			I.ItemName = IR.itemName;
			I.InventoryItemTypeId = IR.itemTypeId;
			I.ModelNumber = IR.modelNumber;
			I.InventoryItemUsageAreaId = IR.itemUsageId;
			I.SerialNumber = IR.serialNumber;
			I.WarrenOrGarantee = IR.warrenOrGarantee;
			I.WarrenOrGarenInfo = IR.warrenOrGarenInfo;
			I.Brand = IR.brandName;
			I.Quantity = IR.quantity;
			I.Price = IR.itemPriceorPerUnit;
			I.VendorName = IR.vendorName;
			I.VendorNumber = IR.vendorNumber;
			I.VendorAddress = IR.vendorAddress;
			I.BillCopy = new byte();

			_dbContext.Inventorys.Add(I);
			_dbContext.SaveChanges();

		}

		// PUT api/<InventoryController>/5
		[HttpPut("UpdateInventory/{id}")]
		public IActionResult UpdateInventory(int id, [FromBody] InventoryReq inventoryReq)
		{
			try
			{
				var updateInventory = _dbContext.Inventorys.Where(X => X.InventoryId == id).FirstOrDefault();
				updateInventory.ItemName = inventoryReq.itemName;
				updateInventory.InventoryItemTypeId = inventoryReq.itemTypeId;
				updateInventory.ModelNumber = inventoryReq.modelNumber;
				updateInventory.InventoryItemUsageAreaId = inventoryReq.itemUsageId;
				updateInventory.SerialNumber = inventoryReq.serialNumber;
				updateInventory.WarrenOrGarantee = inventoryReq.warrenOrGarantee;
				updateInventory.WarrenOrGarenInfo = inventoryReq.warrenOrGarenInfo;
				updateInventory.Brand = inventoryReq.brandName;
				updateInventory.Quantity = inventoryReq.quantity;
				updateInventory.Price = inventoryReq.itemPriceorPerUnit;
				updateInventory.VendorName = inventoryReq.vendorName;
				updateInventory.VendorNumber = inventoryReq.vendorNumber;
				updateInventory.VendorAddress = inventoryReq.vendorAddress;
				updateInventory.BillCopy = new byte();

				_dbContext.SaveChanges();
				return Ok();
			}
			catch (Exception Ex)
			{
				return BadRequest(Ex);
			}

		}

		// DELETE api/<InventoryController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var Result =_dbContext.Inventorys.Where(X => X.InventoryId == id).SingleOrDefault();

			_dbContext.Remove(Result);
			_dbContext.SaveChanges();
		}
	}
}
