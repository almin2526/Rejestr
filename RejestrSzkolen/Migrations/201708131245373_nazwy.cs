namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nazwy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dydaktyk", "Nazwisko", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Dydaktyk", "DataZatrudnienia", c => c.DateTime(nullable: false));
            DropColumn("dbo.Dydaktyk", "LastName");
            DropColumn("dbo.Dydaktyk", "HireDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dydaktyk", "HireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Dydaktyk", "LastName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Dydaktyk", "DataZatrudnienia");
            DropColumn("dbo.Dydaktyk", "Nazwisko");
        }
    }
}
