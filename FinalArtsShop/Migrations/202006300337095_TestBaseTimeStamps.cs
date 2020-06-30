namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestBaseTimeStamps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Counters", "CreatedAt", c => c.DateTime(precision: 0));
            AddColumn("dbo.Counters", "UpdatedAt", c => c.DateTime(precision: 0));
            AddColumn("dbo.OrderItems", "CreatedAt", c => c.DateTime(precision: 0));
            AddColumn("dbo.OrderItems", "UpdatedAt", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "UpdatedAt");
            DropColumn("dbo.OrderItems", "CreatedAt");
            DropColumn("dbo.Counters", "UpdatedAt");
            DropColumn("dbo.Counters", "CreatedAt");
        }
    }
}
