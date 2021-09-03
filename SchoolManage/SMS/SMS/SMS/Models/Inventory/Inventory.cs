using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Inventory
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        //public string ItemCode { get; set; }

        public string ItemName{ get; set; }

        public int ModelNumber { get; set; }

        public int InventoryItemTypeId { get; set; }

        [ForeignKey("InventoryItemTypeId")]
        public InventoryItemType InventoryItemType { get; set; }

        public int InventoryItemUsageAreaId { get; set; }

        [ForeignKey("InventoryItemUsageAreaId")]
        public InventoryItemUsageArea InventoryItemUsageArea { get; set; }

        public string SerialNumber { get; set; }

        public string Brand { get; set; }

        public int Quantity { get; set; }

        public Boolean WarrenOrGarantee { get; set; }

        public string WarrenOrGarenInfo { get; set; }

        public int Price { get; set; }

        public string VendorNumber { get; set; }

        public string VendorName { get; set; }

        public string VendorAddress { get; set; }

        //public byte BillCopy { get; set; }

    }
}
