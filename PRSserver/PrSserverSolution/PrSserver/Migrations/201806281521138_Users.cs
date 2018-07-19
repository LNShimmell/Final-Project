namespace PrSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Lname = c.String(nullable: false, maxLength: 30),
                        Fname = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 255),
                        IsAdmin = c.Boolean(nullable: false),
                        IsReviewer = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            DropTable("dbo.Users");
        }
    }
}
