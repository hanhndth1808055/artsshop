namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Counters", "CountInvoice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Counters", "CountInvoice", c => c.Int());
        }
    }
}
