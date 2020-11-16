using System;
using System.Collections.Generic;

namespace Model
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { set; get; }
        public string phone { set; get; }
        public string customer_email { get; set; }
        public string customer_password { get; set; } 
    }
}
