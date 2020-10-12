using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public  class ProductModel
    {
        public int id { set; get; }
        public string name_pro { set; get; }
        public string image_pro { set; get; }
        public float unit_price { set; get; }
        public int quantity { set; get; }
        public float promotion_price { set; get; }
        public string id_type { set; get; }
        public string description { set; get; }
        public string color { set; get; }
        public int size { set; get; }
        public DateTime? created_at  { set; get; }
    }
}
