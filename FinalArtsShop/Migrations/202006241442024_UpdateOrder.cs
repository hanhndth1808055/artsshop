namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "FulfillmentStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PaymentStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "isReturn", c => c.Int());
            DropColumn("dbo.Orders", "Payment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Payment", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "isReturn");
            DropColumn("dbo.Orders", "PaymentStatus");
            DropColumn("dbo.Orders", "FulfillmentStatus");
            DropColumn("dbo.Orders", "PaymentMethod");
        }
    }
}
