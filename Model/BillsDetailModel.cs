using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class BillsDetailModel
    {
        public string id { get; set; }
        public string bill_id { get; set; }
        public int product_id { get; set; }
        public int quantity_sale { get; set; }
        public float unit_price { get; set; }
        
    }
}
