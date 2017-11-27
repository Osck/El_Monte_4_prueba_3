namespace El_Monte_4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<El_Monte_4.Models.CarcelDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(El_Monte_4.Models.CarcelDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Usuarios.AddOrUpdate(u => u.Username,
                new Models.Usuario() { Username = "admin", Password = "admin" },
                new Models.Usuario() { Username = "jaime", Password = "1234" });

            context.Delito.AddOrUpdate(
                p => p.Id,
                 new Models.Delito { Nombre = "Homicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                 new Models.Delito { Nombre = "Femicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                 new Models.Delito { Nombre = "Robo con Intimidacion", CondenaMinima = 1, CondenaMaxima = 12 },
                 new Models.Delito { Nombre = "Robo en lugar no habitado", CondenaMinima = 1, CondenaMaxima = 5 },
                 new Models.Delito { Nombre = "Cohecho", CondenaMinima = 5, CondenaMaxima = 8 }

               );

        }
    }
}
