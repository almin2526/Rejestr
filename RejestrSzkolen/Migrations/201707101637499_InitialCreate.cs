namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kurs",
                c => new
                    {
                        KursID = c.Int(nullable: false),
                        Tytul = c.String(),
                        Punkty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KursID);
            
            CreateTable(
                "dbo.Zapis",
                c => new
                    {
                        ZapisID = c.Int(nullable: false, identity: true),
                        KursID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Ocena = c.Int(),
                    })
                .PrimaryKey(t => t.ZapisID)
                .ForeignKey("dbo.Kurs", t => t.KursID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.KursID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazwisko = c.String(),
                        Imie = c.String(),
                        DataRejestracji = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zapis", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Zapis", "KursID", "dbo.Kurs");
            DropIndex("dbo.Zapis", new[] { "StudentID" });
            DropIndex("dbo.Zapis", new[] { "KursID" });
            DropTable("dbo.Student");
            DropTable("dbo.Zapis");
            DropTable("dbo.Kurs");
        }
    }
}
