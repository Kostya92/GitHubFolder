namespace CodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
