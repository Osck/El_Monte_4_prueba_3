using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using El_Monte_4.Controllers;

namespace El_Monte_4.Models
{
    public class CarcelDbContext:DbContext
    {
        public DbSet<Preso>Preso { get; set; }

        public DbSet <Condena> Condena { get; set; }

        public DbSet <Juez>Juez { get; set; }

        public DbSet <Delito>Delito { get; set; }

        public DbSet <CondenaDelito>CondenaDelito { get; set; }

		public static implicit operator CarcelDbContext(PresosController v)
		{
			throw new NotImplementedException();
		}
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("carcel");
            base.OnModelCreating(modelBuilder);
        }
    }
}