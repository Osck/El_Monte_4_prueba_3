using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace El_Monte_4.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int ID { get; set; }

        [Index(IsUnique = true), MaxLength(20)]

        public string Username { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}