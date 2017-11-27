using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace El_Monte_4.Models
{
    [Table("Jueces")]
    public class Juez
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Rut { get; set; }

        public bool Sexo { get; set; }
        public string Domicilio { get; set; }

		


    }
}