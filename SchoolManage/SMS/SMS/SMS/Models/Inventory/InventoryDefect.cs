using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Inventory
{
    public class InventoryDefect
    {
        public int InventoryDefectId { get; set; }

		public string ItemName { get; set; }

		public string ItemCode { get; set; }

        public string DefectDesc { get; set; }
    }

    public class InventoryDefectRequest
    {
		public InventoryDefect[] InventoryDefects { get; set; }
	}
}
