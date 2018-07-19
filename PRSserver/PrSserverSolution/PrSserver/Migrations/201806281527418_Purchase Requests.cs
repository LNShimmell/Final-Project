namespace PrSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 120),
                        RejectionReason = c.String(maxLength: 120),
                        DeliveryMode = c.String(maxLength: 20),
                        Status = c.String(maxLength: 15),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequests", "UserID", "dbo.Users");
            DropIndex("dbo.PurchaseRequests", new[] { "UserID" });
            DropTable("dbo.PurchaseRequests");
        }
    }
}
