namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAnnotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropIndex("dbo.Comments", new[] { "ProductId" });
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Districts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.DeliveryTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.DeliveryTypes", "Abbreviation", c => c.String(nullable: false));
            AlterColumn("dbo.Followers", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "Link", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Slides", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Slides", "Image", c => c.String(nullable: false));
            CreateIndex("dbo.Comments", "ProductId");
            AddForeignKey("dbo.Comments", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropIndex("dbo.Comments", new[] { "ProductId" });
            AlterColumn("dbo.Slides", "Image", c => c.String());
            AlterColumn("dbo.Slides", "Name", c => c.String());
            AlterColumn("dbo.Posts", "Body", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Notifications", "Link", c => c.String());
            AlterColumn("dbo.Notifications", "Message", c => c.String());
            AlterColumn("dbo.Followers", "Mail", c => c.String());
            AlterColumn("dbo.DeliveryTypes", "Abbreviation", c => c.String());
            AlterColumn("dbo.DeliveryTypes", "Name", c => c.String());
            AlterColumn("dbo.Districts", "Name", c => c.String());
            AlterColumn("dbo.Comments", "Message", c => c.String());
            AlterColumn("dbo.Comments", "Name", c => c.String());
            AlterColumn("dbo.Comments", "ProductId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Cities", "Name", c => c.String());
            CreateIndex("dbo.Comments", "ProductId");
            AddForeignKey("dbo.Comments", "ProductId", "dbo.Products", "Id");
        }
    }
}
