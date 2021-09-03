using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Inventory
{
    public class InventoryReq
    {
        public string itemCode { get; set; }

        public string itemName { get; set; }

        public int modelNumber { get; set; }

        public int itemTypeId { get; set; }

        public int itemUsageId { get; set; }

        public string serialNumber { get; set; }

        public string brandName { get; set; }

        public int quantity { get; set; }

        public Boolean warrenOrGarantee { get; set; }

        public string warrenOrGarenInfo { get; set; }

        public int itemPriceorPerUnit { get; set; }

        public string vendorNumber { get; set; }

        public string vendorName { get; set; }

        public string vendorAddress { get; set; }

        public byte billCopy { get; set; }
    }
}
