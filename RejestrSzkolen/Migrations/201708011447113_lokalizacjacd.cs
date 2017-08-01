namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lokalizacjacd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lokalizacja",
                c => new
                    {
                        DydaktykID = c.Int(nullable: false),
                        Miejsce = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DydaktykID)
                .ForeignKey("dbo.Dydaktyk", t => t.DydaktykID)
                .Index(t => t.DydaktykID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lokalizacja", "DydaktykID", "dbo.Dydaktyk");
            DropIndex("dbo.Lokalizacja", new[] { "DydaktykID" });
            DropTable("dbo.Lokalizacja");
        }
    }
}
