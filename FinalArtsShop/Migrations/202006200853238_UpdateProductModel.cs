namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AddColumn("dbo.Products", "isNew", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "isActive", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "isFeature", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "CategoryID");
            DropColumn("dbo.Products", "IdType");
            DropColumn("dbo.Products", "New");
            DropColumn("dbo.Products", "Active");
            DropColumn("dbo.Products", "Feature");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Feature", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Active", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "New", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "IdType", c => c.Int(nullable: false));
            DropIndex("dbo.Products", new[] { "CategoryID" });
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "isFeature");
            DropColumn("dbo.Products", "isActive");
            DropColumn("dbo.Products", "isNew");
            CreateIndex("dbo.Products", "CategoryId");
        }
    }
}
