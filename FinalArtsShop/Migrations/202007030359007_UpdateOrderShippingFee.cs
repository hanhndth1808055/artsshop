namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderShippingFee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingFee", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "LineItemsPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "LineItemsPrice");
            DropColumn("dbo.Orders", "ShippingFee");
        }
    }
}
