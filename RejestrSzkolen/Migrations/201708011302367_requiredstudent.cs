namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredstudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Imie", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Imie", c => c.String());
            AlterColumn("dbo.Student", "Nazwisko", c => c.String());
        }
    }
}
