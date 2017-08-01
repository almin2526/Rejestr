namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jednostka",
                c => new
                    {
                        JednostkaID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        DydaktykID = c.Int(),
                    })
                .PrimaryKey(t => t.JednostkaID)
                .ForeignKey("dbo.Dydaktyk", t => t.DydaktykID)
                .Index(t => t.DydaktykID);
            
            AddColumn("dbo.Kurs", "Jednostka_JednostkaID", c => c.Int());
            CreateIndex("dbo.Kurs", "Jednostka_JednostkaID");
            AddForeignKey("dbo.Kurs", "Jednostka_JednostkaID", "dbo.Jednostka", "JednostkaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kurs", "Jednostka_JednostkaID", "dbo.Jednostka");
            DropForeignKey("dbo.Jednostka", "DydaktykID", "dbo.Dydaktyk");
            DropIndex("dbo.Jednostka", new[] { "DydaktykID" });
            DropIndex("dbo.Kurs", new[] { "Jednostka_JednostkaID" });
            DropColumn("dbo.Kurs", "Jednostka_JednostkaID");
            DropTable("dbo.Jednostka");
        }
    }
}
