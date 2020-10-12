using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class CategoryModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parent_id { get; set; }    
        public short? seq_num { get; set; }
        public string url { get; set; }
        public DateTime? created_at { get; set; }
        public List<CategoryModel> children { get; set; }
        public string type { get; set; }

    }
}
