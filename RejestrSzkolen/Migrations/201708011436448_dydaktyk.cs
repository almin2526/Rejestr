namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dydaktyk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dydaktyk",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Imie = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Kurs", "Dydaktyk_ID", c => c.Int());
            CreateIndex("dbo.Kurs", "Dydaktyk_ID");
            AddForeignKey("dbo.Kurs", "Dydaktyk_ID", "dbo.Dydaktyk", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kurs", "Dydaktyk_ID", "dbo.Dydaktyk");
            DropIndex("dbo.Kurs", new[] { "Dydaktyk_ID" });
            DropColumn("dbo.Kurs", "Dydaktyk_ID");
            DropTable("dbo.Dydaktyk");
        }
    }
}
