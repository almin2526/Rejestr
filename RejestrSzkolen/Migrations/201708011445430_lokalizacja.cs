namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lokalizacja : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kurs", "Dydaktyk_ID", "dbo.Dydaktyk");
            DropIndex("dbo.Kurs", new[] { "Dydaktyk_ID" });
            RenameColumn(table: "dbo.Kurs", name: "Jednostka_JednostkaID", newName: "JednostkaID");
            RenameIndex(table: "dbo.Kurs", name: "IX_Jednostka_JednostkaID", newName: "IX_JednostkaID");
            CreateTable(
                "dbo.KursDydaktyk",
                c => new
                    {
                        Kurs_KursID = c.Int(nullable: false),
                        Dydaktyk_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kurs_KursID, t.Dydaktyk_ID })
                .ForeignKey("dbo.Kurs", t => t.Kurs_KursID, cascadeDelete: true)
                .ForeignKey("dbo.Dydaktyk", t => t.Dydaktyk_ID, cascadeDelete: true)
                .Index(t => t.Kurs_KursID)
                .Index(t => t.Dydaktyk_ID);
            
            AlterColumn("dbo.Kurs", "Tytul", c => c.String(maxLength: 50));
            AlterColumn("dbo.Student", "Nazwisko", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Student", "Imie", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Kurs", "Dydaktyk_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kurs", "Dydaktyk_ID", c => c.Int());
            DropForeignKey("dbo.KursDydaktyk", "Dydaktyk_ID", "dbo.Dydaktyk");
            DropForeignKey("dbo.KursDydaktyk", "Kurs_KursID", "dbo.Kurs");
            DropIndex("dbo.KursDydaktyk", new[] { "Dydaktyk_ID" });
            DropIndex("dbo.KursDydaktyk", new[] { "Kurs_KursID" });
            AlterColumn("dbo.Student", "Imie", c => c.String(maxLength: 50));
            AlterColumn("dbo.Student", "Nazwisko", c => c.String(maxLength: 50));
            AlterColumn("dbo.Kurs", "Tytul", c => c.String());
            DropTable("dbo.KursDydaktyk");
            RenameIndex(table: "dbo.Kurs", name: "IX_JednostkaID", newName: "IX_Jednostka_JednostkaID");
            RenameColumn(table: "dbo.Kurs", name: "JednostkaID", newName: "Jednostka_JednostkaID");
            CreateIndex("dbo.Kurs", "Dydaktyk_ID");
            AddForeignKey("dbo.Kurs", "Dydaktyk_ID", "dbo.Dydaktyk", "ID");
        }
    }
}
