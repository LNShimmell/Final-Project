namespace PrSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 60),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Zip = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 255),
                        IsPreapproved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vendors", new[] { "Code" });
            DropTable("dbo.Vendors");
        }
    }
}
