namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "ReturnStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ReturnStatus", c => c.Int(nullable: false));
        }
    }
}
