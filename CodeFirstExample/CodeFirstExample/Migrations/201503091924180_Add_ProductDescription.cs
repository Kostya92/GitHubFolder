namespace CodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ProductDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProductDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ProductDescription");
        }
    }
}
