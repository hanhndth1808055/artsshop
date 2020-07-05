namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Thumbnail", c => c.String());
            AddColumn("dbo.Posts", "View", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Like", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Like");
            DropColumn("dbo.Posts", "View");
            DropColumn("dbo.Posts", "Thumbnail");
        }
    }
}
