using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BillModel
    {

        public string id { get; set; }
        public string name { get; set; }      
        public float total { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime? created_at { get; set; }
        public List<BillDetailModel>listjson_chitiet { get; set; }
    }
}
