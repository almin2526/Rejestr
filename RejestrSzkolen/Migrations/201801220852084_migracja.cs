namespace RejestrSzkolen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Dydaktyk", newName: "Osoba");
            AddColumn("dbo.Osoba", "DataRejestracji", c => c.DateTime());
            AddColumn("dbo.Osoba", "Email", c => c.String());
            AddColumn("dbo.Osoba", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Osoba", "DataZatrudnienia", c => c.DateTime());
            //DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataRejestracji = c.DateTime(nullable: false),
                        Email = c.String(),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Imie = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Osoba", "DataZatrudnienia", c => c.DateTime(nullable: false));
            DropColumn("dbo.Osoba", "Discriminator");
            DropColumn("dbo.Osoba", "Email");
            DropColumn("dbo.Osoba", "DataRejestracji");
            RenameTable(name: "dbo.Osoba", newName: "Dydaktyk");
        }
    }
}
