namespace PrSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(nullable: false),
                        Partnum = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(nullable: false, maxLength: 255),
                        Photopath = c.String(maxLength: 1000),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vendors", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.VendorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendorID", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorID" });
            DropTable("dbo.Products");
        }
    }
}
