using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserModel
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public DateTime? date { get; set; }
        public string address { set; get; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string token { get; set; }
        //  public string image_url { get; set; }
    }
}
