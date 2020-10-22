using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class AuthenticateModel
    {
        [Required]
        public string username { set; get; }
        [Required]
        public string password { set; get; }
    }
}