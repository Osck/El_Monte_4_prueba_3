using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace El_Monte_4.Models
{
    public class Login
    {
        [MaxLength(255)]
        public string Username { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
    }
}