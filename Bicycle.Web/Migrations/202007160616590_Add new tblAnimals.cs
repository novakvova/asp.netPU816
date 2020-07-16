namespace Bicycle.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnewtblAnimals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAnimals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        UrlLink = c.String(maxLength: 1000, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        ModifyDate = c.DateTime(nullable: false, precision: 0),
                        DeleteDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblAnimals");
        }
    }
}
