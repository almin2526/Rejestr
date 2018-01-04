namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wlasciwosci : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jednostka", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jednostka", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
