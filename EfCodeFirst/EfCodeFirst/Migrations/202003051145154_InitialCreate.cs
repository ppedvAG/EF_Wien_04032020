﻿namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abteilung",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GebDatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MitarbeiterAbteilung",
                c => new
                    {
                        Mitarbeiter_Id = c.Int(nullable: false),
                        Abteilung_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mitarbeiter_Id, t.Abteilung_Id })
                .ForeignKey("dbo.Mitarbeiter", t => t.Mitarbeiter_Id, cascadeDelete: true)
                .ForeignKey("dbo.Abteilung", t => t.Abteilung_Id, cascadeDelete: true)
                .Index(t => t.Mitarbeiter_Id)
                .Index(t => t.Abteilung_Id);
            
            CreateTable(
                "dbo.Opfer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Mitarbeiter_Id = c.Int(),
                        Kundennummer = c.String(maxLength: 17),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .ForeignKey("dbo.Mitarbeiter", t => t.Mitarbeiter_Id)
                .Index(t => t.Id)
                .Index(t => t.Mitarbeiter_Id);
            
            CreateTable(
                "dbo.Mitarbeiter",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Beruf = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mitarbeiter", "Id", "dbo.Person");
            DropForeignKey("dbo.Opfer", "Mitarbeiter_Id", "dbo.Mitarbeiter");
            DropForeignKey("dbo.Opfer", "Id", "dbo.Person");
            DropForeignKey("dbo.MitarbeiterAbteilung", "Abteilung_Id", "dbo.Abteilung");
            DropForeignKey("dbo.MitarbeiterAbteilung", "Mitarbeiter_Id", "dbo.Mitarbeiter");
            DropIndex("dbo.Mitarbeiter", new[] { "Id" });
            DropIndex("dbo.Opfer", new[] { "Mitarbeiter_Id" });
            DropIndex("dbo.Opfer", new[] { "Id" });
            DropIndex("dbo.MitarbeiterAbteilung", new[] { "Abteilung_Id" });
            DropIndex("dbo.MitarbeiterAbteilung", new[] { "Mitarbeiter_Id" });
            DropTable("dbo.Mitarbeiter");
            DropTable("dbo.Opfer");
            DropTable("dbo.MitarbeiterAbteilung");
            DropTable("dbo.Person");
            DropTable("dbo.Abteilung");
        }
    }
}
