namespace El_Monte_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roacle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "carcel.Condenas",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        JuezId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("carcel.Jueces", t => t.JuezId, cascadeDelete: true)
                .ForeignKey("carcel.Presos", t => t.PresoId, cascadeDelete: true)
                .Index(t => t.PresoId)
                .Index(t => t.JuezId);
            
            CreateTable(
                "carcel.Jueces",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 255),
                        Rut = c.String(maxLength: 255),
                        Sexo = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "carcel.Presos",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Rut = c.String(maxLength: 255),
                        Nombre = c.String(maxLength: 255),
                        Apellido = c.String(maxLength: 255),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(maxLength: 255),
                        Sexo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "carcel.CondenaDelitos",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CondenaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DelitoId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Condena = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("carcel.Condenas", t => t.CondenaId, cascadeDelete: true)
                .ForeignKey("carcel.Delitos", t => t.DelitoId, cascadeDelete: true)
                .Index(t => t.CondenaId)
                .Index(t => t.DelitoId);
            
            CreateTable(
                "carcel.Delitos",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 255),
                        CondenaMinima = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CondenaMaxima = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "carcel.Usuarios",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Username = c.String(maxLength: 20),
                        Password = c.String(maxLength: 255),
                        Token = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("carcel.CondenaDelitos", "DelitoId", "carcel.Delitos");
            DropForeignKey("carcel.CondenaDelitos", "CondenaId", "carcel.Condenas");
            DropForeignKey("carcel.Condenas", "PresoId", "carcel.Presos");
            DropForeignKey("carcel.Condenas", "JuezId", "carcel.Jueces");
            DropIndex("carcel.Usuarios", new[] { "Username" });
            DropIndex("carcel.CondenaDelitos", new[] { "DelitoId" });
            DropIndex("carcel.CondenaDelitos", new[] { "CondenaId" });
            DropIndex("carcel.Condenas", new[] { "JuezId" });
            DropIndex("carcel.Condenas", new[] { "PresoId" });
            DropTable("carcel.Usuarios");
            DropTable("carcel.Delitos");
            DropTable("carcel.CondenaDelitos");
            DropTable("carcel.Presos");
            DropTable("carcel.Jueces");
            DropTable("carcel.Condenas");
        }
    }
}
