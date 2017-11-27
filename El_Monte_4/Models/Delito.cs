using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace El_Monte_4.Models
{
    [Table("Delitos")]
    public class Delito
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nombre { get; set; }

        public int CondenaMinima { get; set; }

        public int CondenaMaxima { get; set; }

    }
}