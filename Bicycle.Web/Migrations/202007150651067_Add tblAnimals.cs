namespace Bicycle.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblAnimals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAnimals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UrlLink = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblAnimals");
        }
    }
}
