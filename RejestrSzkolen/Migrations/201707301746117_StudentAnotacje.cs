namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAnotacje : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "Nazwisko", c => c.String(maxLength: 50));
            AlterColumn("dbo.Student", "Imie", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Imie", c => c.String());
            AlterColumn("dbo.Student", "Nazwisko", c => c.String());
        }
    }
}
