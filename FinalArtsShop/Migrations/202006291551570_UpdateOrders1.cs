namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrders1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ReturnStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShippedAt", c => c.DateTime());
            AddColumn("dbo.Orders", "ReturnedAt", c => c.DateTime());
            DropColumn("dbo.Orders", "isReturn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "isReturn", c => c.Int());
            DropColumn("dbo.Orders", "ReturnedAt");
            DropColumn("dbo.Orders", "ShippedAt");
            DropColumn("dbo.Orders", "ReturnStatus");
        }
    }
}
