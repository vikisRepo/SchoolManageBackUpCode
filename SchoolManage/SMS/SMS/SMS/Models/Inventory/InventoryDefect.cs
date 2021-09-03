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

        [ForeignKey("InventoryItemTypeId")]
        public InventoryItemType InventoryItemType { get; set; }

        [ForeignKey("InventoryItemUsageAreaId")]
        public InventoryItemUsageArea InventoryItemUsageArea { get; set; }

        public string DefectInfo { get; set; }


    }
}
