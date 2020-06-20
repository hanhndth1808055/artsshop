namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Counters", "Active", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Counters", "Active");
        }
    }
}
